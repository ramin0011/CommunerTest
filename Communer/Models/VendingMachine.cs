using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Communer.Models.Enums;

namespace Communer.Models
{

    public class VendingMachine
    {
        private const int intervalTime = 2;
        public ObservableCollection<MachineLog> Log { get; private set; }

        public VendingMachine()
        {
            Log=new ObservableCollection<MachineLog>();
        }
        public async Task ProcessItem(string item,Enums.VedingMachineActions action)
        {
            switch (action)
            {
                case VedingMachineActions.Boil:
                    await Boil(item);
                    break;
                case VedingMachineActions.Add:
                    await Add(item);
                    break;
                case VedingMachineActions.AddToCup:
                    await AddToCup(item);
                    break;
                case VedingMachineActions.Crush:
                    await Crush(item);
                    break;
                case VedingMachineActions.AddToBlender:
                    await AddToBlender(item);
                    break;
                case VedingMachineActions.BlendAll:
                    await BlendAll();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), action, null);
            }
        }

        private async Task AddToBlender(string item)
        {
            await Task.Delay(TimeSpan.FromSeconds(intervalTime));
            Log.Add(new MachineLog($"Add {item} To Blender"));
        }
        private async Task BlendAll()
        {
            await Task.Delay(TimeSpan.FromSeconds(intervalTime));
            Log.Add(new MachineLog($"Blend Ingredients"));
        }
        private async Task Add(string item)
        {
            await Task.Delay(TimeSpan.FromSeconds(intervalTime));
            Log.Add(new MachineLog($"Add {item}"));
        }

        private async Task AddToCup(string item)
        {
            await Task.Delay(TimeSpan.FromSeconds(intervalTime));
            Log.Add(new MachineLog($"Add {item} To Cup"));
        }

        private async Task Boil(string item)
        {
            await Task.Delay(TimeSpan.FromSeconds(intervalTime));
            Log.Add(new MachineLog($"Boil {item}"));
        }

        private async Task Crush(string item)
        {
            await Task.Delay(TimeSpan.FromSeconds(intervalTime));
            Log.Add(new MachineLog($"Crush {item}"));
        }
    }

    public class MachineLog
    {
        public MachineLog(string text)
        {
            this.Text = text;
            DateTime=DateTime.Now;
        }
        public string Text { get; set; }
        public DateTime DateTime { get; private set; }
    }
}
