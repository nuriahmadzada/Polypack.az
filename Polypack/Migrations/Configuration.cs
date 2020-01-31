namespace Polypack.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Polypack.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Polypack.Data.PolypackContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Polypack.Data.PolypackContext context)
        {
            //context.Headers.AddOrUpdate(x => x.Title,
            //    new Header()
            //    {
            //        Title = "Polymer Azerbaycan",
            //        Subtitle = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Corrupti quidem vitae cum simi.",
            //        Photo = "mainbg.jpg"
            //    });

            //context.Abouts.AddOrUpdate(x => x.IconName,
            //    new About()
            //    {
            //        IconName = "fa flaticon-vehicle34",
            //        IconTitle = "Modern Workshop",
            //        IconSubtitle = "Nunc placerat pharetra lorem. Donec lorem metus lobortis omag sed ipsum lacinia.",
            //        Answer = "Mauris a nunc occideritis me rectum. Videtur quod Ive facillimum, qui fecit vos. Potes me interficere, sine testibus et tunc manere in pauci weeks vel mensis vestigia Isai Pinkman et vos quoque illum occidere. Exercitium inutili option A. Videtur mihi quod autem est. Pergo coctione, et ego, et tu oblivisci Pinkman. Obliviscendum hoc unquam factum. Intelligamus hoc in sola SINGULTO multo aliter atque fructuosa negotium structura. Malo B. Option."

            //    });

            //context.Abouts.AddOrUpdate(x => x.IconName,
            //    new About()
            //    {
            //        IconName = "fa flaticon-worker18",
            //        IconTitle = "Talented Workers",
            //        IconSubtitle = "Nunc placerat pharetra lorem. Donec lorem metus lobortis omag sed ipsum lacinia.",
            //        Answer = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."

            //    });

            //context.Abouts.AddOrUpdate(x => x.IconName,
            //    new About()
            //    {
            //        IconName = "fa flaticon-vehicle3",
            //        IconTitle = "Leading Auto Specialist",
            //        IconSubtitle = "Nunc placerat pharetra lorem. Donec lorem metus lobortis omag sed ipsum lacinia.",
            //        Answer = "Lorem Lorem Lorem Loremmmmm"

            //    });

            //context.Categories.AddOrUpdate(x => x.Name,
            //    new Category()
            //    {
            //        Name = "PVC qida streç filmləri"
            //    });

            //context.Categories.AddOrUpdate(x => x.Name,
            //    new Category()
            //    {
            //        Name = "Pallet streç filmləri"
            //    });

            //context.Categories.AddOrUpdate(x => x.Name,
            //    new Category()
            //    {
            //        Name = "Streç-hud filmləri"
            //    });

            //context.Categories.AddOrUpdate(x => x.Name,
            //    new Category()
            //    {
            //        Name = "Şrink - (termo) filmləri"
            //    });

            //context.Categories.AddOrUpdate(x => x.Name,
            //    new Category()
            //    {
            //        Name = "Alüminium folqalar"
            //    });

            //context.Categories.AddOrUpdate(x => x.Name,
            //    new Category()
            //    {
            //        Name = "Kassa lentləri"
            //    });

            //context.Categories.AddOrUpdate(x => x.Name,
            //    new Category()
            //    {
            //        Name = "Tərəzi etiketləri"
            //    });

            //context.Categories.AddOrUpdate(x => x.Name,
            //    new Category()
            //    {
            //        Name = "Müayinə əlcəkləri"
            //    });

            //context.Services.AddOrUpdate(x => x.IconName,
            //    new Service()
            //    {
            //        IconName = "fa auto16",
            //        IconTitle = "VANS & TRUCKS",
            //        IconSubtitle = "Nunc placerat pharetra lorem dui cinia. Aenean porttitor lectus sit sed amet quis ipsum dolor amet"
            //    });

            //context.Services.AddOrUpdate(x => x.IconName,
            //    new Service()
            //    {
            //        IconName = "fa auto13",
            //        IconTitle = "LUXURY CARS",
            //        IconSubtitle = "Nunc placerat pharetra lorem dui cinia. Aenean porttitor lectus sit sed amet quis ipsum dolor amet"
            //    });

            //context.Services.AddOrUpdate(x => x.IconName,
            //    new Service()
            //    {
            //        IconName = "fa auto14",
            //        IconTitle = "SPORTS CARS",
            //        IconSubtitle = "Nunc placerat pharetra lorem dui cinia. Aenean porttitor lectus sit sed amet quis ipsum dolor amet"
            //    });

            //context.Services.AddOrUpdate(x => x.IconName,
            //    new Service()
            //    {
            //        IconName = "fa auto15",
            //        IconTitle = "SPEED CARS",
            //        IconSubtitle = "Nunc placerat pharetra lorem dui cinia. Aenean porttitor lectus sit sed amet quis ipsum dolor amet"
            //    });

            //context.Partners.AddOrUpdate(x => x.Photo,
            //    new Partner()
            //    {
            //        Photo = "1.png"
            //    });

            //context.Partners.AddOrUpdate(x => x.Photo,
            //    new Partner()
            //    {
            //        Photo = "2.jpg"
            //    });

            //context.Partners.AddOrUpdate(x => x.Photo,
            //    new Partner()
            //    {
            //        Photo = "3.png"
            //    });

            //context.Partners.AddOrUpdate(x => x.Photo,
            //    new Partner()
            //    {
            //        Photo = "4.png"
            //    });

            //context.Partners.AddOrUpdate(x => x.Photo,
            //   new Partner()
            //   {
            //       Photo = "4.png"
            //   });

            //context.Partners.AddOrUpdate(x => x.Photo,
            //   new Partner()
            //   {
            //       Photo = "4.png"
            //   });

            //context.Partners.AddOrUpdate(x => x.Photo,
            //   new Partner()
            //   {
            //       Photo = "4.png"
            //   });

            //context.Partners.AddOrUpdate(x => x.Photo,
            //   new Partner()
            //   {
            //       Photo = "3.png"
            //   });

            //context.Contacts.AddOrUpdate(x => x.Info,
            //    new Contact()
            //    {
            //        Info = "24/7 SUPPORT 0800 123 4567",
            //        Num = "0800 123 4567",
            //        EmailInfo = "EMAIL ADDRESS",
            //        Email = "info@polypack.az",
            //        OpenHours = "OPENING HOURS",
            //        Text = "Mon - Fri 8am to 6pm",
            //        Adress = "Bakı şəhəri, Xətai rayonu, M.Hadi 51"
            //    });

            //context.WeProvides.AddOrUpdate(x => x.TextSection,
            //    new WeProvide()
            //    {
            //        TextSection = "At AutoDoc, We Provide BEST SERVICES YOU CAN COUNT ON!",
            //        Photo = "mainbg.jpg",
            //    });

            //context.Banners.AddOrUpdate(x => x.IconName,
            //    new Banner()
            //    {
            //        IconName = "fa flaticon-wrench63",
            //        IconPercentage = "560",
            //        IconTitle = "MASIN ISTEHSAL",
            //    });

            //context.Banners.AddOrUpdate(x => x.IconName,
            //    new Banner()
            //    {
            //        IconName = "fa flaticon-group12",
            //        IconPercentage = "1407",
            //        IconTitle = "MASIN ISTEHSALATI",
            //    });

            //context.Banners.AddOrUpdate(x => x.IconName,
            //    new Banner()
            //    {
            //        IconName = "fa flaticon-hardbound",
            //        IconPercentage = "3167",
            //        IconTitle = "REVIEWS DONE",
            //    });

            //context.Banners.AddOrUpdate(x => x.IconName,
            //    new Banner()
            //    {
            //        IconName = "fa flaticon-first30",
            //        IconPercentage = "2456",
            //        IconTitle = "PROBLEMS HELLERI",
            //    });

            //context.Banners.AddOrUpdate(x => x.IconName,
            //    new Banner()
            //    {
            //        IconName = "fa flaticon-wrench63",
            //        IconPercentage = "560",
            //        IconTitle = "VEHICLES SERVICED",
            //    });

            //context.Banners.AddOrUpdate(x => x.IconName,
            //    new Banner()
            //    {
            //        IconName = "fa flaticon-setting2",
            //        IconPercentage = "7576",
            //        IconTitle = "DIAGNOSTIC PROBLEM",
            //    });
        }
    }
}
