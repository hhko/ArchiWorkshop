//using System.Collections.Concurrent;
//using System.ComponentModel;
//using System.Diagnostics.CodeAnalysis;
//using System.Globalization;

//namespace ArchiWorkshop.Domains.Abstractions.BaseTypes;

//// TypeConverter 클래스
////  - string -> T
////  - string <- T
//// https://learn.microsoft.com/ko-kr/dotnet/api/system.componentmodel.typeconverter?view=net-8.0
////
////[Fact]
////public void ConvertStringToEntity()
////{
////    // Arrange
////    UserId userId = UserId.New();
////
////    // Act: string -> T
////    UserId actualUseId = (UserId)TypeDescriptor.GetConverter(typeof(UserId)).ConvertFrom(userId.Value.ToString());
////
////    // Assert
////    (actualUseId == userId).Should().BeTrue();
////}

//public sealed class EntityIdConverter : TypeConverter
//{
//    private static readonly ConcurrentDictionary<Type, TypeConverter> ActualConverters = new();
//    private readonly TypeConverter _innerConverter;

//    public EntityIdConverter(Type entityIdType)
//    {
//        _innerConverter = ActualConverters.GetOrAdd(entityIdType, CreateInnerConverter);
//    }

//    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
//    {
//        return _innerConverter.CanConvertFrom(sourceType);
//    }

//    public override bool CanConvertTo(ITypeDescriptorContext? context, [NotNullWhen(true)] Type? destinationType)
//    {
//        return _innerConverter.CanConvertTo(context, destinationType);
//    }

//    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
//    {
//        return _innerConverter.ConvertFrom(context, culture, value);
//    }

//    public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
//    {
//        return _innerConverter.ConvertTo(context, culture, value, destinationType);
//    }

//    private static TypeConverter CreateInnerConverter(Type entityIdType)
//    {
//        if (IsEntityId(entityIdType, out var idType) is false)
//        {
//            throw new InvalidOperationException($"'{entityIdType}' is not an entity id");
//        }

//        var actualConverterType = typeof(EntityIdConverter<>).MakeGenericType(idType);
//        return (TypeConverter)Activator.CreateInstance(actualConverterType, entityIdType)!;
//    }

//    public static bool IsEntityId(Type type, [NotNullWhen(true)] out Type? idType)
//    {
//        if (type is null)
//        {
//            throw new ArgumentNullException(nameof(type));
//        }

//        var @interface = type
//            .GetInterfaces()
//            .Where(@interface => @interface.Name.StartsWith(nameof(IEntityId)))
//            .Where(@interface => @interface.GetGenericArguments()[0] == type)
//            .FirstOrDefault();

//        if (@interface is not null)
//        {
//            idType = @interface.GetGenericArguments()[0];
//            return true;
//        }

//        idType = null;
//        return false;
//    }
//}

//public sealed class EntityIdConverter<TEntityId> : TypeConverter
//    where TEntityId : struct, IEntityId
//{
//    //Cache the method for performance reasons
//    private readonly Func<Ulid, TEntityId> _createIdMethod;

//    public EntityIdConverter(Type type)
//    {
//        _createIdMethod = type.GetMethod(nameof(IEntityId<object>.Create))!.CreateDelegate<Func<Ulid, TEntityId>>();
//    }

//    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
//    {
//        return sourceType == typeof(string)
//            || base.CanConvertFrom(context, sourceType);
//    }

//    public override bool CanConvertTo(ITypeDescriptorContext? context, [NotNullWhen(true)] Type? destinationType)
//    {
//        return destinationType == typeof(string)
//            || base.CanConvertTo(context, destinationType);
//    }

//    /// <summary>
//    /// Convert from ulid in string format to entity id
//    /// </summary>
//    /// <returns>EntityId</returns>
//    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
//    {
//        if (value is string @string)
//        {
//            return _createIdMethod(Ulid.Parse(@string));
//        }

//        return base.ConvertFrom(context, culture, value);
//    }

//    /// <summary>
//    /// Convert from entity id to string 
//    /// </summary>
//    /// <returns>Ulid in string format</returns>
//    /// <exception cref="ArgumentNullException">Thrown if value to convert is null</exception>
//    public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
//    {
//        if (value is null)
//        {
//            throw new ArgumentNullException(nameof(value));
//        }

//        var entityId = (IEntityId)value;
//        var idValue = entityId.Value;

//        if (destinationType == typeof(string))
//        {
//            return idValue.ToString();
//        }

//        return base.ConvertTo(context, culture, value, destinationType);
//    }
//}
