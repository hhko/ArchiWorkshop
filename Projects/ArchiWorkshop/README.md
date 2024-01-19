# Architecture Workshop for Domain-Driven Design 프로젝트

## 아키텍처 구성
### 레이어 프로젝트 구성
```shell
ArchiWorkshop
  # Adapter Layer
  -> ArchiWorkshop.Adapters.Presentation
  -> ArchiWorkshop.Adapters.Persistence -> ArchiWorkshop.Adapters.Infrastructure

  # Application Layer
  -> ArchiWorkshop.Applications

  # Domain Layer
  -> ArchiWorkshop.Domains
```
- `ArchiWorkshop.Applications` 레이어만 `ArchiWorkshop.Domains` 레이어를 참조합니다.

### 레이어 폴더 구성
![](./.images/2024-01-20-06-54-33.png)
- `AssemblyReference.cs`: 네임스페이스 기준으로 어셈블리를 참조할 수 있도록 표준화한다.
- `Abstractions` 폴더에서 레이어 공통 요소와 개별 레이어 구성을 위한 파일을 관리합니다. 
- `{레이어명}LayerRegistration.cs`: 레이어 단위로 DI을 수행한다.
  ```CS
  // DI 네임스페이스를 사용하여 참조와 using 구문을 제거 시킵니다.
  //namespace ArchiWorkshop.Applications.Abstractions.Registrations;
  namespace Microsoft.Extensions.DependencyInjection;

  public static class PersistenceLayerRegistration
  {
    public static IServiceCollection RegisterApplicationLayer(this IServiceCollection services)
    { 
      // ...
    }
  }
  ```


## 요구사항
- ...

<br/>

## 개발 환경
- [코드 커버리지](./Docs/CodeCoverage.md)

<br/>

## 시작 프로젝트 변환
- Console 프로젝트 템플릿을 사용하여 WebApi 시작 프로젝트로 변환합니다.

### 프로젝트 파일 타입 변경
- 변경 전
  ```xml
  <Project Sdk="Microsoft.NET.Sdk">
  ```
- 변경 후
  ```xml
  <Project Sdk="Microsoft.NET.Sdk.Web">
  ```
  - `Properties\launchSettings.json` 파일이 자동 생성됩니다.


## DI 네임스페이스 활용
```
ArchiWorkshop
    참조-> ArchiWorkshop.Adapters.WebApi
        참조-> ArchiWorkshop.Application
```
- ArchiWorkshop에서 ArchiWorkshop.Application 참조 없이 ArchiWorkshop.Application 확장 메서드 사용하기

### DI 네임스페이스 변경 전
```cs
using ArchiWorkshop.Applications.Abstractions.Registrations;

var builder = WebApplication.CreateBuilder();
builder.Services.RegisterApplicationLayer();
```
- ArchiWorkshop.Applications 참조 추가
- `using ArchiWorkshop.Applications.Abstractions.Registrations;` 구문 추가

### DI 네임스페이스 변경 후(Microsoft.Extensions.DependencyInjection)
```cs
var builder = WebApplication.CreateBuilder();
builder.Services.RegisterApplicationLayer();
```
- ~~ArchiWorkshop.Applications 참조 추가~~가 불필요하다.
- ~~`using ArchiWorkshop.Applications.Abstractions.Registrations;` 구문 추가~~가 불필요하다.
- ArchiWorkshop.Host에서 ArchiWorkshop.Application의 확장 메서드를 참조와 using 구문 추가 없이 바로 사용할 수 있다.

<br/>

## 타입
- [Result 타입(성공/실패 처리 타입)](./Docs/Result.md)
