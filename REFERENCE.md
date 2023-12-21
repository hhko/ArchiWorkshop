## Nesting a Value Object inside an Entity
- [Nesting a Value Object inside an Entity](https://enterprisecraftsmanship.com/posts/nesting-value-object-inside-entity/)
- Value Objects **Rules**
  - structural equality
  - immutable
  - **serialize: the whole collection into a string when persisting it to a data store.**
    - 이슈
      - that solution is sub-optimal if you need to perform a search among those Value Objects using standard database features.
      - It is also not the best implementation if the number of items in the collection is too high as it might cause performance issues.
- 이슈 코드: 통합 테이블
  ```cs
  public sealed class City : ValueObject<City>
  {
    ...
  }

  public sealed class User : Entity
  {
    private IList<City> _cities;
    public IReadOnlyList<City> Cities => _cities;   // 이슈
    ...
  }
  ```
- 해결 코드: 개별 테이블
  ```cs
  public sealed class City : ValueObject<City>
  {
    ...
  }

  internal class CityInUser : Entity              // 해결
  {
    public City City { get; protected set; }
    public User User { get; protected set; }

    public CityInUser(City city, User user)
    {
      City = city;
      User = user;
    }
  }

  public sealed class User : Entity
  {
    private IList<CityInUser> _cities;

    public IReadOnlyList<City> Cities =>          // 해결
      _cities
        .Select(x => x.City)
        .ToList();

    public void AddCity(City city)
    {
      _cities.Add(new CityInUser(city, this));
    }
  }
  ```
