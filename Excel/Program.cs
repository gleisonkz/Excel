using Autofac;
using Excel.Class;
using Excel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel
{
    static class Program
    {
        public static IContainer Container { get; private set; }        

        [STAThread]
        static void Main()
        {
            var form = new Form1();
            var builder = new ContainerBuilder();
            builder.RegisterType<FuncoesNovaEstrutura>();
            builder.RegisterType<StrategyValidacoesTipoEmailEmpresa>();
            builder.RegisterType<StrategyValidacoesTipoEmailContador>();
            builder.RegisterType<StrategyValidacoesTipoTelefone>();
            builder.RegisterType<StrategyValidacoesTipoNuEmpregados>();
            builder.RegisterType<StrategyValidacoesTipoEmailNaoClassificado>();
            builder.RegisterInstance(form).As<IDados>();


            Container = builder.Build();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(form);
        }
    }
}
