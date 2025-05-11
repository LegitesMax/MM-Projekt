namespace TCC.Asp.Controller
{
    public abstract class GenericController<TAccesModel, TViewModel> 
        where TViewModel : class, new() 
        where TAccesModel : class, new()
    {
        protected virtual TAccesModel ToTAccesModel(TViewModel viewModel)
        {
            var result = new TAccesModel();

            throw new NotImplementedException();
        }

        protected virtual TViewModel ToViewModel(TViewModel viewModel)
        {
            var result = new TViewModel();

            throw new NotImplementedException();
        }
    }
}
