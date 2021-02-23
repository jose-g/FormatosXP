using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Web;
//using System.Web.Http.Routing;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace MGP.CI.SEGURIDAD.Presentacion.Helpers
{
    public static class HtmlHelpers 
    {

        public static MvcHtmlString CascadeDropDownList<TModel, TProperty, T, To, To2>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> model, List<T> List, Expression<Func<T, To>> dataValue, Expression<Func<T, To2>> textValue, String urlHelper, Expression<Func<TModel, TProperty>> UpdateTarget, String dataFilter, FormMethod formMethod)
        {

            return CascadeDropDownList(htmlHelper, model, List, dataValue, textValue, urlHelper, UpdateTarget, dataFilter, formMethod);

        }

        public static MvcHtmlString CascadeDropDownList<TModel, TProperty, T, To, To2>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> model,
            List<T> List,
            Expression<Func<T, To>> dataValue, Expression<Func<T, To2>> textValue, String urlHelper, Expression<Func<TModel, TProperty>> UpdateTarget, String dataFilter, FormMethod formMethod, object htmlAttributes)
        {
            var dataValueMemberExpression = (MemberExpression)dataValue.Body;
            var textValueMemberExpression = (MemberExpression)textValue.Body;
            var updateTargetemberExpression = (MemberExpression)UpdateTarget.Body;
            var htmlAttributesDict = new RouteValueDictionary(htmlAttributes);

            if (!htmlAttributesDict.ContainsKey("class"))
                htmlAttributesDict.Add("class", "");

            htmlAttributesDict.Add("data-type", "cascade-dropdow-list");
            htmlAttributesDict.Add("data-update-target", "#" + updateTargetemberExpression.Member.Name);
            htmlAttributesDict.Add("data-filter", dataFilter);
            htmlAttributesDict.Add("data-http-method", formMethod);
            htmlAttributesDict.Add("data-url", ConstantHelpers.RUTA_BASE_SERVICIOS + urlHelper);

            return htmlHelper.DropDownListFor(model, new SelectList(List, dataValueMemberExpression.Member.Name, textValueMemberExpression.Member.Name), "[--Seleccione--]", htmlAttributesDict);
        }

        public static MvcHtmlString CascadeDropDownList<TModel, TProperty, T, To, To2>
            (this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> model,
            String urlHelper,
            Expression<Func<TModel, TProperty>> UpdateTarget,
            String dataFilter,
            FormMethod formMethod,
            object htmlAttributes)
        {
            return CascadeDropDownList(htmlHelper, model, (List<T>)Enumerable.Empty<SelectListItem>(), (Expression<Func<T, To>>)null, (Expression<Func<T, To2>>)null, urlHelper, UpdateTarget, dataFilter, formMethod);
        }

        public static MvcHtmlString DisplayModal(this HtmlHelper htmlHelper, String Target)
        {

            return new MvcHtmlString(String.Format("data-toggle=\"{0}\" data-target=\"#{1}\" data-type=\"modal\"", "modal", Target));
        }
    }
}