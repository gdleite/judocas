#pragma checksum "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8f1946def6c3fe0126bcee1b3251b9ae4d59664e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Professores_Details), @"mvc.1.0.view", @"/Views/Professores/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Professores/Details.cshtml", typeof(AspNetCore.Views_Professores_Details))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\_ViewImports.cshtml"
using judocas;

#line default
#line hidden
#line 2 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\_ViewImports.cshtml"
using judocas.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f1946def6c3fe0126bcee1b3251b9ae4d59664e", @"/Views/Professores/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b3b6330b8d591e13ff646a051e8f6d9005cb8e9", @"/Views/_ViewImports.cshtml")]
    public class Views_Professores_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<judocas.Models.Professor>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(33, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(78, 123, true);
            WriteLiteral("\r\n<h2>Details</h2>\r\n\r\n<div>\r\n    <h4>Professor</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(202, 40, false);
#line 14 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Nome));

#line default
#line hidden
            EndContext();
            BeginContext(242, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(286, 36, false);
#line 17 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml"
       Write(Html.DisplayFor(model => model.Nome));

#line default
#line hidden
            EndContext();
            BeginContext(322, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(366, 47, false);
#line 20 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.RegistroCbj));

#line default
#line hidden
            EndContext();
            BeginContext(413, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(457, 43, false);
#line 23 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml"
       Write(Html.DisplayFor(model => model.RegistroCbj));

#line default
#line hidden
            EndContext();
            BeginContext(500, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(544, 45, false);
#line 26 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Telefone1));

#line default
#line hidden
            EndContext();
            BeginContext(589, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(633, 41, false);
#line 29 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml"
       Write(Html.DisplayFor(model => model.Telefone1));

#line default
#line hidden
            EndContext();
            BeginContext(674, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(718, 45, false);
#line 32 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Telefone2));

#line default
#line hidden
            EndContext();
            BeginContext(763, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(807, 41, false);
#line 35 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml"
       Write(Html.DisplayFor(model => model.Telefone2));

#line default
#line hidden
            EndContext();
            BeginContext(848, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(892, 41, false);
#line 38 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
            EndContext();
            BeginContext(933, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(977, 37, false);
#line 41 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml"
       Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
            EndContext();
            BeginContext(1014, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1058, 39, false);
#line 44 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CPF));

#line default
#line hidden
            EndContext();
            BeginContext(1097, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1141, 35, false);
#line 47 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml"
       Write(Html.DisplayFor(model => model.CPF));

#line default
#line hidden
            EndContext();
            BeginContext(1176, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1220, 47, false);
#line 50 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Observacoes));

#line default
#line hidden
            EndContext();
            BeginContext(1267, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1311, 43, false);
#line 53 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml"
       Write(Html.DisplayFor(model => model.Observacoes));

#line default
#line hidden
            EndContext();
            BeginContext(1354, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1398, 50, false);
#line 56 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DataNascimento));

#line default
#line hidden
            EndContext();
            BeginContext(1448, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1492, 46, false);
#line 59 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml"
       Write(Html.DisplayFor(model => model.DataNascimento));

#line default
#line hidden
            EndContext();
            BeginContext(1538, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1582, 45, false);
#line 62 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.RG.Numero));

#line default
#line hidden
            EndContext();
            BeginContext(1627, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1671, 41, false);
#line 65 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml"
       Write(Html.DisplayFor(model => model.RG.Numero));

#line default
#line hidden
            EndContext();
            BeginContext(1712, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1756, 53, false);
#line 68 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.RG.OrgaoExpedidor));

#line default
#line hidden
            EndContext();
            BeginContext(1809, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1853, 49, false);
#line 71 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml"
       Write(Html.DisplayFor(model => model.RG.OrgaoExpedidor));

#line default
#line hidden
            EndContext();
            BeginContext(1902, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1963, 41, false);
#line 74 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Faixa));

#line default
#line hidden
            EndContext();
            BeginContext(2004, 221, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            <table class=\"table\">\r\n                <tr>\r\n                    <th>Descriçao da faixa</th>\r\n                    <th>Cor da faixa</th>\r\n                </tr>\r\n");
            EndContext();
#line 82 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml"
                 foreach (var item in Model.Faixa)
                {

#line default
#line hidden
            BeginContext(2296, 84, true);
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(2381, 44, false);
#line 86 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Descricao));

#line default
#line hidden
            EndContext();
            BeginContext(2425, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(2517, 38, false);
#line 89 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Cor));

#line default
#line hidden
            EndContext();
            BeginContext(2555, 60, true);
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 92 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml"
                }

#line default
#line hidden
            BeginContext(2634, 124, true);
            WriteLiteral("            </table>\r\n        </dd>\r\n        <dd>\r\n            .\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2759, 44, false);
#line 99 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Endereco));

#line default
#line hidden
            EndContext();
            BeginContext(2803, 380, true);
            WriteLiteral(@"
        </dt>
        <dd class=""col-sm-10"">
            <table class=""table"">
                <tr>
                    <th>Estado</th>
                    <th>Cidade</th>
                    <th>Rua</th>
                    <th>CEP</th>
                    <th>Numero</th>
                </tr>
                <tr>
                    <td>
                        ");
            EndContext();
            BeginContext(3184, 47, false);
#line 112 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Endereco.Estado));

#line default
#line hidden
            EndContext();
            BeginContext(3231, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3311, 47, false);
#line 115 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Endereco.Cidade));

#line default
#line hidden
            EndContext();
            BeginContext(3358, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3438, 44, false);
#line 118 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Endereco.Rua));

#line default
#line hidden
            EndContext();
            BeginContext(3482, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3562, 44, false);
#line 121 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Endereco.CEP));

#line default
#line hidden
            EndContext();
            BeginContext(3606, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3686, 47, false);
#line 124 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Endereco.Numero));

#line default
#line hidden
            EndContext();
            BeginContext(3733, 172, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>         \r\n            </table>\r\n        </dd>\r\n        <dd>\r\n            .\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(3905, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8f1946def6c3fe0126bcee1b3251b9ae4d59664e18994", async() => {
                BeginContext(3951, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 135 "C:\Users\leite\OneDrive\Área de Trabalho\Projetos\Facul\GIT\judocas\judocas\judocas\Views\Professores\Details.cshtml"
                           WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3959, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(3967, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8f1946def6c3fe0126bcee1b3251b9ae4d59664e21354", async() => {
                BeginContext(3989, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4005, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<judocas.Models.Professor> Html { get; private set; }
    }
}
#pragma warning restore 1591