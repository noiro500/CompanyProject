using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProject.API.Infrastructure.ViewComponents
{
    public class Cards: ViewComponent
    {
        private readonly IRepository<Page> _context;

        public Cards(IRepository<Page> ctx)
        {
            _context=ctx;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var pages = await _context.GetCollectionGenericAsync("ToCard");
            var cardList=new List<Card>();
            foreach (var card in pages)
            {
                cardList.Add(
                    new Card(card.ScreenName.ToUpper(), "Home", card.Name, card.Name + ".png")
                    );
            }
            //pages.AsParallel().ForAll(p=>
            //    cardList.Add(new Card(p.ScreenName.ToUpper(), "Home",p.Name,p.Name+".png"))
            //);
            return View("Cards", cardList);
        }
    }
}
