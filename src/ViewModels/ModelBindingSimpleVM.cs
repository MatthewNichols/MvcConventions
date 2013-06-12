using System.ComponentModel;

namespace MvcConventions.ViewModels
{
    public class ModelBindingSimpleVM
    {
        [DisplayName("Name : ")]
        public string Name { get; set; }

        [DisplayName("Age : ")]
        public int Age { get; set; }
    }
}