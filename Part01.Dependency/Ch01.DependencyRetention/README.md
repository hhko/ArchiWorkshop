# 의존성 유지(Dependency Retention)

## 목차
- 순수 함수 vs. 불순 함수
  - 불순 함수 예제
  - 순수 함수 예제
- 의존성 정의
- 관리해야할 의존성 종류
- 요구사항
- 요구사항 구현(의존성 유지, Dependency Retention)

<br/>

## 순수 함수 vs. 불순 함수
- **순수(Pure) 함수**
  > - 함수의 결과값은 파라미터(parameter)로 넘겨진 입력값에 의해서만 결정된다.  
  >   _the function return values are identical for identical arguments._
  > - 부작용(side effects)이 없다.  
  >   _the function has no side effects._  
  >   함수의 실행이 함수 결괏값 외 외부에 영향을 끼치지 않는다.
  - 테스트(디버깅)하기 쉽다.
    - (입력값에 의해 결괏값을) 예측할 수 있고 결정적이다(predictable and deterministic).
    - (입력값에 의해 결괏값을) 제어할 수 있다.
- **불순(Impure) 함수**
  > - 함수의 결과값은 파라미터(parameter)로 넘겨진 입력값에 의해서만 결정되지 않는다.
  > - 부작용(side effects)이 있다.  
  >   함수의 실행이 함수 결괏값 외 외부에 영향을 끼친다.
  - 테스트(디버깅)하기 어렵다.
    - (입력값에 의해 결괏값을) 예측할 수 없고 비결정적이다(unpredictable and non-deterministic).
    - (입력값에 의해 결괏값을) 제어할 수 없다.
      - 예
        - 시간
        - 난수 생성기
        - I/O
        - 네트워크
        - ...

### 불순 함수 예제
```cs
public class Program
{
    private static string _member = "StringOne";

    // 불순 함수
    public static void HyphenatedConcat(string append)
    {
        // 1. 함수의 결과값은 파라미터(parameter)로 넘겨진 입력값에 의해서만 결정되지 않는다.
        // 2. 부작용이 있다: 정적 멤버 변수 _member을 수정한다.
        //    - 함수의 실행이 함수 결괏값 외 외부(정적 멤버 변수)에 영향을 끼친다.
        _member += '-' + append;
    }

    public static void Main()
    {
        HyphenatedConcat("StringTwo");
        Console.WriteLine(_member);
    }
}
```

```cs
public class Program
{
    // 불순 함수
    public static void HyphenatedConcat(StringBuilder sb, string append)
    {
        // 1. 함수의 결과값은 파라미터(parameter)로 넘겨진 입력값에 의해서만 결정되지 않는다.
        // 2. 부작용이 있다: 입력 변수 sb을 수정한다.
        //    - 함수의 실행이 함수 결괏값 외 외부(정적 멤버 변수)에 영향을 끼친다.
        sb.Append('-' + append);
    }

    public static void Main()
    {
        StringBuilder sb = new StringBuilder("StringOne");
        HyphenatedConcat(sb, "StringTwo");
        Console.WriteLine(sb);
    }
}
```

### 순수 함수 예제
```cs
class Program
{
    // 순수 함수
    public static string HyphenatedConcat(string s, string append)
    {
        // 1. 함수의 결과값은 파라미터(parameter)로 넘겨진 입력값에 의해서만 결정된다.
        // 2. 부작용이 없다.
        return (s + '-' + append);
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(HyphenatedConcat("StringOne", "StringTwo"));
    }
}
```

<br/>

## 의존성 정의
- 함수 A가 함수 B를 호출하면 함수 A는 함수 B에 의존한다.
  - 호출자(A)/피호출자(B) 의존성
  - caller/callee dependency

<br/>

## 관리해야할 의존성 종류
```
1. 관리 대상 X: 불순 함수 -호출-> 불순 함수
2. 관리 대상 X: 불순 함수 -호출-> 순수 함수
3. 관리 대상 O: 순수 함수 -호출-> 불순 함수     // 불순 의존성(Impure dependencies): 피호출자의 불순함이 전염된다.
4. 관리 대상 X: 순수 함수 -호출-> 순수 함수
5. 관리 대상 O: 순수 함수 -호출-> 순수 함수1    // 전략 의존성(Strategy dependencies): 런타임 시 피호출자의 동작을 변경한다.
                             -> 순수 함수2
                             -> ...
```

- **불순 의존성(Impure dependencies)**: 피호출자(callee)가 불순 함수일 때
  ```
  순수 함수 -호출-> 불순 함수
  ```
  - 이유: 호출자가 런타임 시 피호출자(callee)의 **전염(불순)을 차단하고 싶을 때**  
    순수 함수가 불순 함수를 호출하면 순수 함수까지 불순 함수가 된다(전염된다: 테스트하기 어렵게 된다).
- **전략 의존성(Strategy dependencies)**: 피호출자(callee)가 순수 함수일 때
  ```
  순수 함수 -호출-> 순수 함수1
                -> 순수 함수2
                -> ...
  ```
  - 이유: 호출자가 런타임 시 피호출자(callee)의 **동작을 변경하고 싶을 때**

<br/>

## 요구사항
- 콘솔에서 문자열 2개를 입력 받는다.
- 문자열 2개를 비교한다.
- 첫 번째 문자열이 두 번째 문자열보다 크거나 작거나 같은지 콘솔에 출력한다.

<br/>

## 요구사항 구현(의존성 유지, Dependency retention)


<br/>

## 참고 자료
- [Pure function](https://en.wikipedia.org/wiki/Pure_function)
- [Refactor into pure functions](https://learn.microsoft.com/ko-kr/dotnet/standard/linq/refactor-pure-functions)
- [Six approaches to dependency injection](https://fsharpforfunandprofit.com/posts/dependencies/)
