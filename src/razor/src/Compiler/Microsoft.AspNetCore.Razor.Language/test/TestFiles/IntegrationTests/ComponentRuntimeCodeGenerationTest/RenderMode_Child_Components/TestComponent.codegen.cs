﻿// <auto-generated/>
#pragma warning disable 1591
namespace Test
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Components;
    public partial class TestComponent : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<global::Test.TestComponent>(0);
            global::Microsoft.AspNetCore.Components.IComponentRenderMode __renderMode = 
#nullable restore
#line 1 "x:\dir\subdir\Test\TestComponent.cshtml"
                            Microsoft.AspNetCore.Components.Web.RenderMode.Server

#line default
#line hidden
#nullable disable
            ;
            __builder.AddAttribute(1, "ChildContent", (global::Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<global::Test.TestComponent>(2);
                global::Microsoft.AspNetCore.Components.IComponentRenderMode __renderMode2_0 = 
#nullable restore
#line 2 "x:\dir\subdir\Test\TestComponent.cshtml"
                                Microsoft.AspNetCore.Components.Web.RenderMode.Server

#line default
#line hidden
#nullable disable
                ;
                __builder2.AddAttribute(3, "ChildContent", (global::Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<global::Test.TestComponent>(4);
                    global::Microsoft.AspNetCore.Components.IComponentRenderMode __renderMode3_0 = 
#nullable restore
#line 3 "x:\dir\subdir\Test\TestComponent.cshtml"
                                    Microsoft.AspNetCore.Components.Web.RenderMode.Server

#line default
#line hidden
#nullable disable
                    ;
                    __builder3.AddComponentRenderMode(__renderMode3_0);
                    __builder3.CloseComponent();
                }
                ));
                __builder2.AddComponentRenderMode(__renderMode2_0);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(5, "\r\n ");
                __builder2.OpenComponent<global::Test.TestComponent>(6);
                global::Microsoft.AspNetCore.Components.IComponentRenderMode __renderMode2_1 = 
#nullable restore
#line 5 "x:\dir\subdir\Test\TestComponent.cshtml"
                             Microsoft.AspNetCore.Components.Web.RenderMode.Server

#line default
#line hidden
#nullable disable
                ;
                __builder2.AddAttribute(7, "ChildContent", (global::Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<global::Test.TestComponent>(8);
                    global::Microsoft.AspNetCore.Components.IComponentRenderMode __renderMode3_0 = 
#nullable restore
#line 6 "x:\dir\subdir\Test\TestComponent.cshtml"
                                    Microsoft.AspNetCore.Components.Web.RenderMode.Server

#line default
#line hidden
#nullable disable
                    ;
                    __builder3.AddComponentRenderMode(__renderMode3_0);
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(9, "\r\n        ");
                    __builder3.OpenComponent<global::Test.TestComponent>(10);
                    global::Microsoft.AspNetCore.Components.IComponentRenderMode __renderMode3_1 = 
#nullable restore
#line 7 "x:\dir\subdir\Test\TestComponent.cshtml"
                                    Microsoft.AspNetCore.Components.Web.RenderMode.Server

#line default
#line hidden
#nullable disable
                    ;
                    __builder3.AddComponentRenderMode(__renderMode3_1);
                    __builder3.CloseComponent();
                }
                ));
                __builder2.AddComponentRenderMode(__renderMode2_1);
                __builder2.CloseComponent();
            }
            ));
            __builder.AddComponentRenderMode(__renderMode);
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 12 "x:\dir\subdir\Test\TestComponent.cshtml"
 
    [Parameter]
    public RenderFragment ChildContent { get; set; }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
