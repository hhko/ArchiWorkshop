# 의존성 유지(Dependency Retention)

## 목차
- 요구사항
- 요구사항 구현(의존성 유지, Dependency Retention)

<br/>

## 요구사항
- 콘솔에서 문자열 2개를 입력 받는다.
- 문자열 2개를 비교한다.
- 첫 번째 문자열이 두 번째 문자열보다 크거나 작거나 같은지 콘솔에 출력한다.

<br/>

## 요구사항 구현(의존성 유지, Dependency retention)
> **목표**
> - 불순 함수를 이해합니다.
> - 불순 함수에 포함된 **유스 케이스(문자열 비교)는** 테스트하기 힘들다.
> - 불순 함수 안에 있는 '유스 케이스(문자열 비교)'을 테스트하는 건 어렵습니다.

![](./images/2023-12-09-23-05-52.png)

```cs
public static void CompareTwoStrings()
{
    // 입력: 콘솔에서 문자열 2개를 입력 받는다.
    Console.WriteLine("Enter the first value");
    string? first = Console.ReadLine();
    Console.WriteLine("Enter the second value");
    string? second = Console.ReadLine();

    // 비교: 문자열 2개를 비교한다.
    int compare = string.Compare(first, second);

    // 출력: 비교 결과를 출력한다.
    if (compare > 0)
        Console.WriteLine("The first value is bigger");
    else if (compare < 0)
        Console.WriteLine("The first value is smaller");
    else
        Console.WriteLine("The values are equal");
}
```
- **`CompareTwoStrings`은 불순 함수입니다.**
  - CompareTwoStrings 함수는 입/출력이 없기 때문에(`void`) 불순 함수입니다.
    > 순수 함수는 입력값으로 결괏값을 제어할 수 있어야 하기 때문에 입력이 반드시 존재해야 합니다.
  - CompareTwoStrings 함수는 불순 코드(I/O 입/출력 함수: ReadLine, WriteLine)를 호출하고 있어 불순 함수입니다.
    > I/O 입/출력 함수는 사용자가 입력하는 값에 의존하기 때문에 우리가 직접 제어할 수 없는 함수입니다. 즉, 이 함수들은 예측하기 어려운 불순 함수입니다.
- **`CompareTwoStrings`은 테스트하기 어렵습니다.**
  - 문자열 비교(순수 함수) 유스 케이스만을 분리하여 테스트할 수 없습니다.

<br/>

## 참고 자료
- [Six approaches to dependency injection](https://fsharpforfunandprofit.com/posts/dependencies/)
