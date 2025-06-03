namespace Ex04.Menus.Interfaces
{
    public interface IListener<T>
    {
        void ReportChosen(T i_menuItem);
    }
}
