namespace WebFlightBusiness.Services;

public interface IBusinessService<TModel> where TModel : class
{
    TModel Add(TModel model);
    List<TModel> GetAll();
    TModel Get(int id);
    TModel Update(TModel model);
    TModel Delete(int id);
}