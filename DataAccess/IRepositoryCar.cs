namespace DataAccess;

public interface IRepositoryCar<T>
{
    void Add(T item);
    IEnumerable<T> GetAll();
    IEnumerable<T> GetByMakeAndModel(string make, string model);
    void UpdateMake(object id, string make);
    void UpdateModel(object id, string model);
    void UpdateColor(object id, string color);
    void UpdateHorsePower(object id, int horsepower);
    void Replace(object id, T item);
    void Delete(object id);
}