# 패키지 ID                              버전           명령
# --------------------------------------------------------------------
# dotnet-coverage                        17.9.6        dotnet-coverage
# dotnet-reportgenerator-globaltool      5.2.0         reportgenerator

# /ArchiWorkshop                                     // 솔루션 Root
#    /TestResults                                    // 테스트 자동화 결과
#        /19f5be57-f7f1-4902-a22d-ca2dcd8fdc7a       // dotnet test: 코드 커버리지 N개
#            /coverage.cobertura.xml
#
#            /merged-coverage.cobertura.xml          // dotnet-coverage: Merged 코드 커버리지
#
#            /CodeCoverageReport                     // ReportGenerator: 코드 커버리지 Html, Badges
#                /...

$current_dir = Get-Location
$testResults_dir = Join-Path -Path $current_dir -ChildPath "TestResults"

# 이전 테스트 결과 정리(TestResults 폴더 정리)
if (Test-Path -Path $testResults_dir) {
    Remove-Item -Path (Join-Path -Path $testResults_dir -ChildPath "*") -Recurse -Force
}

# NuGet 패키지 복원
dotnet restore $current_dir

# 솔루션 빌드
dotnet build $current_dir --no-restore --configuration Release --verbosity m

# 솔루션 테스트
dotnet test `
    --configuration Release `
    --results-directory $testResults_dir `
    --no-build `
    --collect "XPlat Code Coverage" `
    --verbosity normal

# 코드 커버리지 머지
dotnet-coverage merge (Join-Path -Path $testResults_dir -ChildPath "**/*.cobertura.xml") `
    -f cobertura `
    -o (Join-Path -Path $testResults_dir -ChildPath "merged-coverage.cobertura.xml")

# 코드 커버리지 HTML
reportgenerator `
	-reports:(Join-Path -Path $testResults_dir -ChildPath "merged-coverage.cobertura.xml") `
	-targetdir:(Join-Path -Path $testResults_dir -ChildPath "CodeCoverageReport") `
	-reporttypes:"Html;Badges" `
    -verbosity:Info


