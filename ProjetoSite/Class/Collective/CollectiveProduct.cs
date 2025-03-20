using ProjetoSite.Class.Base;
using ProjetoSite.Class.DTO;

namespace ProjetoSite.Class.Collective
{
    public class CollectiveProduct : BaseCollective
    {
        public List<ProductDTO> ObjList(ProductDTO objDTO)
        {
            try
            {
                List<ProductDTO> objList = new List<ProductDTO>();
                foreach (object[] array in SelectArray(objDTO))
                {
                    ProductDTO obj = FillClass<ProductDTO>(array);
                    obj.FillSubClass();
                    objList.Add(obj);
                }
                return objList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ProductDTO ObjOne(ProductDTO objDTO)
        {
            try
            {
                foreach (object[] array in SelectArray(objDTO))
                {
                    ProductDTO obj = FillClass<ProductDTO>(array);
                    obj.FillSubClass();
                    return obj;
                }
                return new ProductDTO();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
