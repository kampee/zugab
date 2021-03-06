﻿using Ninject.Modules;

using ZuegerAdressbook.Service;
using ZuegerAdressbook.ViewModels;

namespace ZuegerAdressbook
{
    public class IocConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<IDocumentStoreFactory>().To<DocumentStoreFactory>().InTransientScope();
            Bind<IMessageDialogService>().To<MessageDialogService>();
            Bind<IDispatcher>().To<ApplicationDispatcher>();
            Bind<IExcelImportService>().To<ExcelImportService>();
            Bind<IExcelExportService>().To<ExcelExportService>();

            Bind<MainViewModel>().ToSelf().InTransientScope();
            Bind<PersonViewModel>().ToSelf().InTransientScope();
            Bind<DocumentViewModel>().ToSelf().InTransientScope();
            Bind<PrintPersonDetailsViewModel>().ToSelf().InTransientScope();
        }
    }
}
