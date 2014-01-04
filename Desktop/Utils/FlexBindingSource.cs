using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace Desktop.Utils
{
    public static class FlexReflector
    {
        public static string GetPropertyName<T>(Expression<Func<T>> expression)
        {
            if (expression.Body.NodeType == ExpressionType.MemberAccess)
            {
                return (expression.Body as MemberExpression).Member.Name;
            }
            throw new NotSupportedException("This overload accepts only member access lambda expressions");
        }

        public static string GetPropertyName<TItem, TResult>(Expression<Func<TItem, TResult>> expression)
        {
            switch (expression.Body.NodeType)
            {
                case ExpressionType.MemberAccess:
                    return (expression.Body as MemberExpression).Member.Name;
                case ExpressionType.Call:
                    var callExpression = expression.Body as MethodCallExpression;
                    return callExpression.Method.Name;
                case ExpressionType.Convert:
                    var unaryExpression = expression.Body as UnaryExpression;
                    return GetMemberName(unaryExpression.Operand);
                case ExpressionType.Parameter:
                case ExpressionType.Constant: //Change
                    return String.Empty;
                default:
                    throw new ArgumentException("The expression is not a member access or method call expression");
            }

            if (expression.Body.NodeType == ExpressionType.MemberAccess)
            {
                return (expression.Body as MemberExpression).Member.Name;
            }
            throw new NotSupportedException("This overload accepts only member access lambda expressions");
        }

        private static string GetMemberName(Expression expression)
        {
            switch (expression.NodeType)
            {
                case ExpressionType.MemberAccess:
                    var memberExpression = (MemberExpression)expression;
                    var supername = GetMemberName(memberExpression.Expression);
                    if (String.IsNullOrEmpty(supername))
                    {
                        return memberExpression.Member.Name;
                    }

                    return String.Concat(supername, '.', memberExpression.Member.Name);
                case ExpressionType.Call:
                    var callExpression = (MethodCallExpression)expression;
                    return callExpression.Method.Name;
                case ExpressionType.Convert:
                    var unaryExpression = (UnaryExpression)expression;
                    return GetMemberName(unaryExpression.Operand);
                case ExpressionType.Parameter:
                case ExpressionType.Constant: //Change
                    return String.Empty;
                default:
                    throw new ArgumentException("The expression is not a member access or method call expression");
            }
        }

        public static string Name<T, T2>(Expression<Func<T, T2>> expression)
        {
            return GetMemberName(expression.Body);
        }

        //NEW
        public static string Name<T>(Expression<Func<T>> expression)
        {
            return GetMemberName(expression.Body);
        }

        public static void Bind<TC, TD, TP>(this TC control, Expression<Func<TC, TP>> controlProperty, TD dataSource, Expression<Func<TD, TP>> dataMember) where TC : Control
        {
            control.DataBindings.Add(Name(controlProperty), dataSource, Name(dataMember));
        }

        public static void BindLabelText<T>(this Label control, T dataObject, Expression<Func<T, object>> dataMember)
        {
            // as this is way one any type of property is ok
            control.DataBindings.Add("Text", dataObject, Name(dataMember));
        }

        public static void BindEnabled<T>(this Control control, T dataObject, Expression<Func<T, bool>> dataMember)
        {       
           control.Bind(c => c.Enabled, dataObject, dataMember);
        }
    }
    

    public static class FlexReflectorExtensions
    {
        public static string GetPropertyName<T>(this T instance, Expression<Func<T, object>> propertyAccesor)
        {
            return FlexReflector.GetPropertyName(propertyAccesor);
        }

        public static void SetLookupBinding(ListControl toBind, object dataSource, string displayMember, string valueMember)
        {
            toBind.DisplayMember = displayMember;
            toBind.ValueMember = valueMember;

            // Only after the following line will the listbox receive events due to binding.
            toBind.DataSource = dataSource;
        }
    }

    public class FlexBindingSource<TDataSource>
    {
        private BindingSource _winFormsBindingSource;
        public FlexBindingSource()
        {
            this._winFormsBindingSource = new BindingSource();
            _winFormsBindingSource.DataSource = typeof(TDataSource);
        }

        /// <summary>
        /// Creates a DataBinding between a control property and a datasource property
        /// </summary>
        /// <typeparam name="TControl">The control type, must derive from System.Winforms.Control</typeparam>
        /// <param name="controlInstance">The control instance on wich the databinding will be added</param>
        /// <param name="controlPropertyAccessor">A lambda expression which specifies the control property to be databounded (something like textboxCtl => textboxCtl.Text)</param>
        /// <param name="datasourceMemberAccesor">A lambda expression which specifies the datasource property (something like datasource => datasource.Property) </param>
        public void CreateBinding<TControl>(TControl controlInstance, Expression<Func<TControl, object>> controlPropertyAccessor, Expression<Func<TDataSource, object>> datasourceMemberAccesor) where TControl : Control
        {
            this.CreateBinding(controlInstance, controlPropertyAccessor, datasourceMemberAccesor, DataSourceUpdateMode.OnValidation);
        }

        /// <summary>
        /// Creates a DataBinding between a control property and a datasource property
        /// </summary>
        /// <typeparam name="TControl">The control type, must derive from System.Winforms.Control</typeparam>
        /// <param name="controlInstance">The control instance on wich the databinding will be added</param>
        /// <param name="controlPropertyAccessor">A lambda expression which specifies the control property to be databounded (something like textboxCtl => textboxCtl.Text)</param>
        /// <param name="datasourceMemberAccesor">A lambda expression which specifies the datasource property (something like datasource => datasource.Property) </param>
        /// <param name="dataSourceUpdateMode">See control.DataBindings.Add method </param>
        private void CreateBinding<TControl>(TControl controlInstance, Expression<Func<TControl, object>> controlPropertyAccessor, Expression<Func<TDataSource, object>> datasourceMemberAccesor, DataSourceUpdateMode dataSourceUpdateMode)
            where TControl : Control
        {
            string controlPropertyName = FlexReflector.GetPropertyName(controlPropertyAccessor);
            string sourcePropertyName = FlexReflector.GetPropertyName(datasourceMemberAccesor);
            controlInstance.DataBindings.Add(controlPropertyName, _winFormsBindingSource, sourcePropertyName, true, dataSourceUpdateMode);
        }

        private TDataSource _currentItem = default(TDataSource);
        public TDataSource CurrentItem
        {
            get
            {
                return _currentItem;
            }
            set
            {
                _currentItem = value;

                if (value == null)
                    this._winFormsBindingSource.DataSource = typeof(TDataSource);
                else
                    this._winFormsBindingSource.DataSource = value;
            }
        }
    }
}

