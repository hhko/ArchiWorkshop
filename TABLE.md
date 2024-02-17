### 솔루션 프로젝트 구성
- Layer
- Test

### 솔루션 설정 구성

- https://github.com/PublicApiGenerator/PublicApiGenerator

## ?
1. WebApi 기본 코드
   - 기본 함수
   - long 함수

## 솔루션 재구성
1. 관찰(observability) 시스템
1. 솔루션 레이어 구주화
   - WebApi 모듈 Host에서 분리
1. 솔루션 구성 파일
   - .editorconfig
   - .gitattributes
   - .gitignore
   - Directory.Build.props
   - Directory.Build.targets
   - Directory.Packages.props
   - .vscode
     - extensions.json
     - launch.json
     - settings.json
     - tasks.json
1. 테스트 자동화
   - 통합 테스트
   - BDD?
   - Snapshot
   - 코드 커버리지: VSCode
1. CI
   - 구분
     - Local: powershell
     - Remote: GitHub Actions
   - 빌드
   - 테스트
   - 코드 커버리지
   - 정적 코드 분석?
   - 코드 형식?
1. 컨테이너화
1. 로그
   - 호스트 로그 -> otel-collector
   - 컨테이너 로그 -std?-> otel-collector
1. CD

## ...
