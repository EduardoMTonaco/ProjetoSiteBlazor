using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using ProjetoSite.Class.Collective;
using ProjetoSite.Class.DTO;
using ProjetoSite.Components.Pages.Product;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ProjetoSite.Components.Pages
{
    public partial class HomePage
    {
        private ProductModal productModal;
        private bool isOpen = false;

        private void AbrirModal()
        {
            isOpen = false;
            isOpen = true;
        }
        public void FecharModal()
        {
           isOpen = false;
        }
    }
}
