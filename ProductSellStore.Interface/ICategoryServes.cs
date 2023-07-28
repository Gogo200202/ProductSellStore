using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace ProductSellStore.Interface
{
    public interface ICategoryServes
    {
        public Task AddCategory(string categoyName);

        public Task RemoveCategory(string categoyName);
        public Task<List<Category>> AllCategory();
    }
}
