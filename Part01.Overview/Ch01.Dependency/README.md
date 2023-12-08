# 의존성 유지(retention) vs. 거부(rejection)

## 순수 vs. 불순
- 순수(Pure)
  > 테스트하기 쉽다.
  - 예측할 수 있고 결정적이다(predictable and deterministic).
  - 제어할 수 있다.
- 불순(Impure)
  > 테스트하기 어렵다.
  - 예측할 수 없고 비결정적이다(unpredictable and non-deterministic).
  - 제어할 수 없다.
  - 예
    - 시간
    - 난수 생성기
    - I/O
    - 네트워크
    - ...

## 의존성 정의
- 함수 A가 함수 B를 호출하면 함수 A는 함수 B에 의존한다.
  - 호출자(A)/피호출자(B) 의존성
  - caller/callee dependency

## 관리해야할 의존성 종류
- `불순 의존성(Impure dependencies)`: 피호출자(callee)가 불순 함수일 때
  > 순수 함수 -호출-> 불순 함수
  - 이유: **호출자가 런타임 시 피호출자(callee) 불순함의 전염으로부터 관리하고 싶을 때**
  - 영향: 불순함이 전염되면 호출자까지 결과론적으로 불순 함수가 된다(테스트하기 어렵게 된다).
- `전략 의존성(Strategy dependencies)`: 피호출자(callee)가 순수 함수일 때
  > 순수 함수 -호출-> 순수 함수1
  >               -> 순수 함수2
  >               -> ...
  - 이유: **호출자가 런타임 시 피호출자(callee) 동작을 변경하고 싶을 때**

<br/>

## 예제 코드
> - 요구사항
>   - 콘솔에서 문자열 2개를 입력 받는다.
>   - 문자열 2개를 비교한다.
>   - 첫 번째 문자열이 두 번째 문자열보다 크거나 작거나 같은지 콘솔에 출력한다.

### 의존성 유지(Dependency retention)

### 의존성 거부(Dependency rejection)

<br/>

## 참고 자료
- [Six approaches to dependency injection](https://fsharpforfunandprofit.com/posts/dependencies/)