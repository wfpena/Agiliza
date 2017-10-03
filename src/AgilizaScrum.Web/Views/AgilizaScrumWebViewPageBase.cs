using Abp.Web.Mvc.Views;

namespace AgilizaScrum.Web.Views
{
    public abstract class AgilizaScrumWebViewPageBase : AgilizaScrumWebViewPageBase<dynamic>
    {

    }

    public abstract class AgilizaScrumWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected AgilizaScrumWebViewPageBase()
        {
            LocalizationSourceName = AgilizaScrumConsts.LocalizationSourceName;
        }
    }
}