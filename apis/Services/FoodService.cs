using apis.Model;

namespace apis.Services
{
    public class FoodService
    {
        public async Task<Food> GetFoodById(string id)
        {
            return DataBase.GetrContext.Context.Foods.FirstOrDefault(f => f.FoodId == id);
        }
    }
}
