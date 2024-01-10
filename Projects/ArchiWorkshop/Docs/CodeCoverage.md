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
```

## 코드 커버리지
### 폴더 구성
```
├─ArchiWorkshop.sln
├─Src
│  └─ArchiWorkshop.Domains
├─Tests
│  └─ArchiWorkshop.Tests.Unit
│
└─TestResults
   ├─Cobertura-Coverage.xml
   └─CoverageReport
      ├─index.html
      └─...
```

### CLI
```shell
#
# .sln 파일이 있는 곳에서 CLI 명령을 실행합니다.
#

# 빌드
dotnet build --configuration Release --verbosity m

# 테스트 실행 및 코드 커버리지 데이터 생성하기
dotnet-coverage collect -f cobertura -o TestResults/Cobertura-Coverage.xml "dotnet test --no-build --verbosity n"
dotnet-coverage collect -f cobertura -o TestResults/Cobertura-Coverage.xml "dotnet test --no-build --verbosity n --filter FullyQualifiedName!=ArchiWorkshop.Tests.Unit"

# 코드 커버리즈 HTML 생성하기
reportgenerator `
	-reports:TestResults/Cobertura-Coverage.xml `
	-targetdir:TestResults/CoverageReport `
	-reporttypes:"Html;Badges"
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

## TODO
- ArchiWorkshop.Tests.Unit 코드 커버리지 제외
- N개 테스트일 때 통합 코드 커버리지 구하기

