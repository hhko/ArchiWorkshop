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
> - 불순 함수를 이해한다.

![](./images/2023-12-09-23-05-52.png)

```cs
public static void CompareTwoStrings()
{
    // 콘솔에서 문자열 2개를 입력 받는다.
    Console.WriteLine("Enter the first value");
    string? first = Console.ReadLine();
    Console.WriteLine("Enter the second value");
    string? second = Console.ReadLine();

    // 문자열 2개를 비교한다.
    int compare = string.Compare(first, second);
    if (compare > 0)
        Console.WriteLine("The first value is bigger");       // 첫 번째가 두 번째 문자열보다 크다.
    else if (compare < 0)
        Console.WriteLine("The first value is smaller");      // 첫 번째가 두 번째 문자열보다 작다
    else
        Console.WriteLine("The values are equal");            // 첫 번째와 두 번째 문자열이 같다.
}
```
- **`CompareTwoStrings`은 불순 함수다.**
  - CompareTwoStrings 함수는 입/출력이 없기 때문에(`void`) 불순 함수다.
  - CompareTwoStrings 함수는 불순 코드(I/O 입/출력 함수: ReadLine, WriteLine)를 호출하고 있어 불순 함수다.
- **`CompareTwoStrings`은 테스트하기 힘들다.**
  - 순수 코드(문자열 비고)만 테스트할 수 없다(유스 케이스만을 테스트할 수 없다).

<br/>

## 참고 자료
- [Six approaches to dependency injection](https://fsharpforfunandprofit.com/posts/dependencies/)
