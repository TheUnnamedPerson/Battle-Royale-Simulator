﻿#pragma checksum "C:\Users\Unnam\Documents\Battle Royale Simulator\BattleRoyaleSimulator\CharacterDataEditor.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D24330512074163D815546E90BCFAB4F53EC79A959E895264116B88BF652430A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BattleRoyaleSimulator
{
    partial class CharacterDataEditor : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(global::Windows.UI.Xaml.Controls.ItemsControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.ItemsSource = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class CharacterDataEditor_obj4_Bindings :
            global::Windows.UI.Xaml.IDataTemplateExtension,
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            ICharacterDataEditor_Bindings
        {
            private global::BattleRoyaleSimulator.Character dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::System.WeakReference obj4;
            private global::Windows.UI.Xaml.Controls.TextBlock obj6;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj6TextDisabled = false;

            public CharacterDataEditor_obj4_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 218 && columnNumber == 202)
                {
                    isobj6TextDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 4: // CharacterDataEditor.xaml line 208
                        this.obj4 = new global::System.WeakReference((global::Windows.UI.Xaml.Controls.Viewbox)target);
                        break;
                    case 6: // CharacterDataEditor.xaml line 218
                        this.obj6 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    default:
                        break;
                }
            }

            public void DataContextChangedHandler(global::Windows.UI.Xaml.FrameworkElement sender, global::Windows.UI.Xaml.DataContextChangedEventArgs args)
            {
                 if (this.SetDataRoot(args.NewValue))
                 {
                    this.Update();
                 }
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                ProcessBindings(args.Item, args.ItemIndex, (int)args.Phase, out nextPhase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
                Recycle();
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
                switch(phase)
                {
                    case 0:
                        nextPhase = -1;
                        this.SetDataRoot(item);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            (this.obj4.Target as global::Windows.UI.Xaml.Controls.Viewbox).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                }
                this.Update_((global::BattleRoyaleSimulator.Character) item, 1 << phase);
            }

            public void Recycle()
            {
            }

            // ICharacterDataEditor_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::BattleRoyaleSimulator.Character)newDataRoot;
                    return true;
                }
                return false;
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::BattleRoyaleSimulator.Character obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_name(obj.name, phase);
                    }
                }
            }
            private void Update_name(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // CharacterDataEditor.xaml line 218
                    if (!isobj6TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj6, obj, null);
                    }
                }
            }
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class CharacterDataEditor_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            ICharacterDataEditor_Bindings
        {
            private global::BattleRoyaleSimulator.CharacterDataEditor dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.ListView obj2;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj2ItemsSourceDisabled = false;

            public CharacterDataEditor_obj1_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 204 && columnNumber == 98)
                {
                    isobj2ItemsSourceDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 2: // CharacterDataEditor.xaml line 204
                        this.obj2 = (global::Windows.UI.Xaml.Controls.ListView)target;
                        break;
                    default:
                        break;
                }
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
            }

            public void Recycle()
            {
                return;
            }

            // ICharacterDataEditor_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::BattleRoyaleSimulator.CharacterDataEditor)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::BattleRoyaleSimulator.CharacterDataEditor obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_storedCharacters(obj.storedCharacters, phase);
                    }
                }
            }
            private void Update_storedCharacters(global::System.Collections.Generic.List<global::BattleRoyaleSimulator.Character> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // CharacterDataEditor.xaml line 204
                    if (!isobj2ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj2, obj, null);
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // CharacterDataEditor.xaml line 204
                {
                    this.StoredCharactersView = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.StoredCharactersView).SelectionChanged += this.CharacterView_Selected;
                }
                break;
            case 5: // CharacterDataEditor.xaml line 217
                {
                    global::Windows.UI.Xaml.Controls.Button element5 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element5).Click += this.Delete_Click;
                }
                break;
            case 7: // CharacterDataEditor.xaml line 186
                {
                    this.BackButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.BackButton).Click += this.BackButton_Click;
                }
                break;
            case 8: // CharacterDataEditor.xaml line 25
                {
                    this.EditorPanel = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 9: // CharacterDataEditor.xaml line 172
                {
                    this.StabSlider = (global::Windows.UI.Xaml.Controls.Slider)(target);
                }
                break;
            case 10: // CharacterDataEditor.xaml line 161
                {
                    this.DetSlider = (global::Windows.UI.Xaml.Controls.Slider)(target);
                }
                break;
            case 11: // CharacterDataEditor.xaml line 150
                {
                    this.RsrflSlider = (global::Windows.UI.Xaml.Controls.Slider)(target);
                }
                break;
            case 12: // CharacterDataEditor.xaml line 139
                {
                    this.EmpSlider = (global::Windows.UI.Xaml.Controls.Slider)(target);
                }
                break;
            case 13: // CharacterDataEditor.xaml line 128
                {
                    this.DilSlider = (global::Windows.UI.Xaml.Controls.Slider)(target);
                }
                break;
            case 14: // CharacterDataEditor.xaml line 117
                {
                    this.CharismaSlider = (global::Windows.UI.Xaml.Controls.Slider)(target);
                }
                break;
            case 15: // CharacterDataEditor.xaml line 106
                {
                    this.MarSlider = (global::Windows.UI.Xaml.Controls.Slider)(target);
                }
                break;
            case 16: // CharacterDataEditor.xaml line 95
                {
                    this.IntSlider = (global::Windows.UI.Xaml.Controls.Slider)(target);
                }
                break;
            case 17: // CharacterDataEditor.xaml line 84
                {
                    this.SanitySlider = (global::Windows.UI.Xaml.Controls.Slider)(target);
                }
                break;
            case 18: // CharacterDataEditor.xaml line 73
                {
                    this.ChaosSlider = (global::Windows.UI.Xaml.Controls.Slider)(target);
                }
                break;
            case 19: // CharacterDataEditor.xaml line 62
                {
                    this.LuckSlider = (global::Windows.UI.Xaml.Controls.Slider)(target);
                }
                break;
            case 20: // CharacterDataEditor.xaml line 51
                {
                    this.ConsSlider = (global::Windows.UI.Xaml.Controls.Slider)(target);
                }
                break;
            case 21: // CharacterDataEditor.xaml line 38
                {
                    this.nameInput = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 22: // CharacterDataEditor.xaml line 40
                {
                    this.IdInput = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 23: // CharacterDataEditor.xaml line 32
                {
                    global::Windows.UI.Xaml.Controls.Button element23 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element23).Click += this.Button_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // CharacterDataEditor.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    CharacterDataEditor_obj1_Bindings bindings = new CharacterDataEditor_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            case 4: // CharacterDataEditor.xaml line 208
                {                    
                    global::Windows.UI.Xaml.Controls.Viewbox element4 = (global::Windows.UI.Xaml.Controls.Viewbox)target;
                    CharacterDataEditor_obj4_Bindings bindings = new CharacterDataEditor_obj4_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(element4.DataContext);
                    element4.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Windows.UI.Xaml.DataTemplate.SetExtensionInstance(element4, bindings);
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element4, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

