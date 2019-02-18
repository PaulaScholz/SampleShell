//***********************************************************************
//
// Copyright (c) 2019 Microsoft Corporation. All rights reserved.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
//**********************************************************************​

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SampleShell_3
{
    /// <summary>
    /// This is the SamplePage. It contains the Sample content and can call
    /// MainPage.NotifyUser through the MainPage.Current reference.
    /// </summary>
    public sealed partial class SamplePage : Page
    {
        public SamplePage()
        {
            this.InitializeComponent();

            // Call NotifyUser through the static MainPage.Current and say hello.
            //
            // For those unfamiliar with the C# null conditional operator, see
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-conditional-operators

            MainPage.Current?.NotifyUser("Hello from the Sample Page!", NotifyType.StatusMessage);
        }

        private void Button_Normal(object sender, RoutedEventArgs e)
        {
            MainPage.Current?.NotifyUser("NotifyType.StatusMessage", NotifyType.StatusMessage);
        }

        private void Button_Warning(object sender, RoutedEventArgs e)
        {
            MainPage.Current?.NotifyUser("NotifyType.WarningMessage", NotifyType.WarningMessage);
        }

        private void Button_Error(object sender, RoutedEventArgs e)
        {
            MainPage.Current?.NotifyUser("NotifyType.ErrorMessage", NotifyType.ErrorMessage);
        }

        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            MainPage.Current?.NotifyUser("NotifyType.ClearMessage", NotifyType.ClearMessage);
        }
    }
}
