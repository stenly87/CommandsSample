using System.Windows;

namespace WpfApp14
{
    internal class AnotherClassWithLogic
    {
        public CustomCommand<string> CommandWithParameter { get; set; }
        public CustomCommand SimpleCommand { get; set; }

        public AnotherClassWithLogic()
        {
            CommandWithParameter = new CustomCommand<string>(
                s => MessageBox.Show(s),
                s => !string.IsNullOrEmpty(s)
                );

            SimpleCommand = new CustomCommand(
                () => MessageBox.Show("Это сообщение из класса " + this));
        }
    }
}