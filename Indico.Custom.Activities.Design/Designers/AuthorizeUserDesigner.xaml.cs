using System.Collections.Generic;

namespace Indico.Custom.Activities.Design
{
    /// <summary>
    /// Interaction logic for AuthorizeUserDesigner.xaml
    /// </summary>
    public partial class AuthorizeUserDesigner
    {
        public AuthorizeUserDesigner()
        {
            InitializeComponent();
            UserEmailExpression.ExpressionType = typeof(List<string>);
        }
    }
}
