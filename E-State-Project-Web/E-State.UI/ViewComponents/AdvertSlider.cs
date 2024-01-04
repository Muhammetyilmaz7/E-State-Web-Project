using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace E_State.UI.ViewComponents
{
    public class AdvertSlider : ViewComponent
    {
        ImagesService im;
        public AdvertSlider(ImagesService im)
        {
            this.im = im;
        }
        public IViewComponentResult Invoke()
        {
            var list = im.List(x => x.Status == true);
            return View(list);
        }
    }
}
