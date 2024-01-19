using System.Diagnostics.CodeAnalysis;

namespace GuildSaber.ApiStruct;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "ValueParameterNotUsed")]
public struct PagedList<T>
{
    public PagedList()
    {
        Data = new List<T>();
    }

    public PagedList(List<T> p_Data, int p_Page, int p_PageSize, int p_TotalCount)
    {
        Data       = p_Data;
        Page       = p_Page;
        PageSize   = p_PageSize;
        TotalCount = p_TotalCount;

        TotalPages      = (int)Math.Ceiling(TotalCount / (double)PageSize);
        HasPreviousPage = Page            > 1;
        HasNextPage     = Page * PageSize < TotalCount;
    }

    ////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////

    public List<T> Data            { get; set; }
    public int     Page            { get; set; }
    public int     PageSize        { get; set; }
    public int     TotalCount      { get; set; }
    public int     TotalPages      { get; set; }
    public bool    HasPreviousPage { get; set; }
    public bool    HasNextPage     { get; set; }

    ////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////
}
