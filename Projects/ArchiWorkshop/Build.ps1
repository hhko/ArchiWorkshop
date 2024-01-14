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

if (Test-Path -Path $testResults_dir) {
    Remove-Item -Path (Join-Path -Path $testResults_dir -ChildPath "*") -Recurse -Force
}

dotnet restore $current_dir

dotnet build $current_dir --no-restore --configuration Release --verbosity m

dotnet test `
    --configuration Release `
    --results-directory $testResults_dir `
    --no-build `
    --collect "XPlat Code Coverage" `
    --verbosity normal

dotnet-coverage merge (Join-Path -Path $testResults_dir -ChildPath "**/*.cobertura.xml") `
    -f cobertura `
    -o (Join-Path -Path $testResults_dir -ChildPath "merged-coverage.cobertura.xml")

reportgenerator `
	-reports:(Join-Path -Path $testResults_dir -ChildPath "merged-coverage.cobertura.xml") `
	-targetdir:(Join-Path -Path $testResults_dir -ChildPath "CodeCoverageReport") `
	-reporttypes:"Html;Badges" `
    -verbosity:Info


