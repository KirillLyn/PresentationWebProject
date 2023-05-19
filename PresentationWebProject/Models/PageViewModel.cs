namespace PresentationWebProject.Models
{
	public class PageViewModel
	{
		public int CountPage { get; private set; }
		public List<Presentation> ListPresent { get; private set; }
		public PageViewModel(int count, List<Presentation> list) {
			CountPage = count;
			ListPresent = list;
		}
	}
}
