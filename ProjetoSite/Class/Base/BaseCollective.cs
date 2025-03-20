using ProjetoSite.Class.Attributes;
using ProjetoSite.Class.DTO;
using System.ComponentModel;
using System.Reflection;

namespace ProjetoSite.Class.Base
{
    public abstract class BaseCollective
    {
        
        public int MaxAmount = 0;
        public static string RemoveSQLInjection(string value)
        {
            return value.Replace("-", "").Replace("'", "");
        }
        public T FillClass<T>(object[] dados) where T : new()
        {
            T obj = new T();
            PropertyInfo[] propriedades = typeof(T).GetProperties();

            foreach (var propriedade in propriedades)
            {
                var atributo = propriedade.GetCustomAttributes(typeof(DisplayAttributes), false)
                                           .FirstOrDefault() as DisplayAttributes;

                if (atributo != null && atributo.Column < dados.Length)
                {
                    if (dados[atributo.Column] != DBNull.Value)
                    {
                        if (propriedade.PropertyType.AssemblyQualifiedName.Contains("DateTime"))
                        {
                            propriedade.SetValue(obj, (DateTime)dados[atributo.Column]);
                        }
                        else if (propriedade.PropertyType.AssemblyQualifiedName.Contains("Boolean"))
                        {
                            propriedade.SetValue(obj, (bool)dados[atributo.Column]);
                        }
                        else
                        {
                            propriedade.SetValue(obj, Convert.ChangeType(dados[atributo.Column], propriedade.PropertyType));
                        }
                    }                       
                }
            }
            return obj;
        }
        public List<Array> SelectArray(BaseDTO objDTO)
        {
            return SQLHandler.SQLReader(objDTO.SelectCommand());
        }
        public void Update(BaseDTO objDTO)
        {
            SQLHandler.SQLCommand(objDTO.UpdateCommand());
        }
        public void Insert(BaseDTO objDTO)
        {
            SQLHandler.SQLCommand(objDTO.InsertCommand());
        }
    }
}
