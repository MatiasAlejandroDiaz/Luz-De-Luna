using System.Threading.Tasks;
namespace Extencion
{
    public static class TaskExtencion
    {
        public static async void WrapErrors(this Task task)
        {
            await task;
        }
    }
}