using LinkDev.Talabat.Domain.Entites.Products;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.Talabat.Domain.Spesfications.Products
{
    public class ProudctWithBrandAndCategorySpacefications:BaseSpesfications<Product, int>
    {

        public ProudctWithBrandAndCategorySpacefications(string sort, int? brandId, int? categoryID,int pageIndex,int pageSize,string? search)
            : base(p=>
                (string.IsNullOrEmpty(search) || EF.Functions.Like(p.NormalizedName, $"%{search}%")) &&
                (!brandId.HasValue || p.BrandId == brandId.Value) &&
                (!categoryID.HasValue || p.CategoryId == categoryID.Value)

            )
        {
            Includes.Add(x => x.Brand!);
            Includes.Add(x => x.Category!);
            //sorting

            if (!string.IsNullOrEmpty(sort))
            {

            switch (sort.ToLower())
            {
                case "priceasc":
                    {
                        OrderBy = p => p.Price;
                        break;
                    }
                case "pricedesc":
                    {
                        OrderByDesc = p => p.Price;
                        break;
                    }
                default:
                    {
                        OrderBy = p => p.Name;
                        break;
                    }
            }
            }
            else
            {
                OrderBy = p => p.Name;
            }

            Addpaging(pageSize * (pageIndex - 1), pageSize);


        }
        public ProudctWithBrandAndCategorySpacefications(int id)
            : base(id)
        {
            Includes.Add(x => x.Brand!);
            Includes.Add(x => x.Category!);
        }

        public ProudctWithBrandAndCategorySpacefications(int? brandId, int? categoryId,string? search)
            : base(p =>

               (string.IsNullOrEmpty(search) || EF.Functions.Like(p.NormalizedName, $"%{search}%")) &&
                (!brandId.HasValue || p.BrandId == brandId.Value) &&
                (!categoryId.HasValue || p.CategoryId == categoryId.Value) 

            )
        {
            
        }
    }
}
