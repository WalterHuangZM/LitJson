using LitJson;

public interface IJsonConvert<T>
{
    T Convert(IJsonWrapper input);
}
