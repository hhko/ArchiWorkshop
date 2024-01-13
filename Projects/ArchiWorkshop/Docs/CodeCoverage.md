## 도구 설치
```shell
# 전역 도구 목록 확인하기
dotnet tool list -g

# 전역 도구 설치
dotnet tool install -g dotnet-coverage
dotnet tool install -g dotnet-reportgenerator-globaltool

# 전역 도구 업데이트
dotnet tool update -g dotnet-coverage
dotnet tool update -g dotnet-reportgenerator-globaltool

# 패키지 ID                              버전           명령
# --------------------------------------------------------------------
# dotnet-coverage                        17.9.6        dotnet-coverage
# dotnet-reportgenerator-globaltool      5.2.0         reportgenerator
```

## 코드 커버리지
### 폴더 구성
```
/ArchiWorkshop                                     // 솔루션 Root
   /TestResults                                    // 테스트 자동화 결과
       /19f5be57-f7f1-4902-a22d-ca2dcd8fdc7a       // dotnet test: 코드 커버리지 N개
           /coverage.cobertura.xml

           /merged-coverage.cobertura.xml          // dotnet-coverage: Merged 코드 커버리지

           /CodeCoverageReport                     // ReportGenerator: 코드 커버리지 Html, Badges
               /...
```

### CLI
```shell
#
# .sln 파일이 있는 곳에서 CLI 명령을 실행합니다.
#

$current_dir = Get-Location
$testResult_dir = Join-Path -Path $current_dir -ChildPath "TestResults"

if (Test-Path -Path $testResult_dir) {
    Remove-Item -Path (Join-Path -Path $testResult_dir -ChildPath "*") -Recurse -Force
}
dotnet restore $current_dir

dotnet build $current_dir --no-restore --configuration Release --verbosity m

dotnet test `
    --configuration Release `
    --results-directory $testResult_dir `
    --no-build `
    --collect "XPlat Code Coverage" `
    --verbosity normal

dotnet-coverage merge (Join-Path -Path $testResult_dir -ChildPath "**/*.cobertura.xml") `
    -f cobertura `
    -o (Join-Path -Path $testResult_dir -ChildPath "merged-coverage.cobertura.xml")

reportgenerator `
	-reports:(Join-Path -Path $testResult_dir -ChildPath "merged-coverage.cobertura.xml") `
	-targetdir:(Join-Path -Path $testResult_dir -ChildPath "CodeCoverageReport") `
	-reporttypes:"Html;Badges" `
    -verbosity:Info

```

## 코드 커버리지 제외
### 소스 코드
```cs
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class Hello
{

}
```