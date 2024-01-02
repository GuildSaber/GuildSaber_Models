using System.Diagnostics.CodeAnalysis;

namespace GuildSaber.ApiStruct;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "ValueParameterNotUsed")]
public struct PagedList<T>
{
    private readonly int  m_TotalPages;
    private readonly bool m_HasPreviousPage;
    private readonly bool m_HasNextPage;

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
    }

    ////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////

    public List<T> Data       { get; set; }
    public int     Page       { get; set; }
    public int     PageSize   { get; set; }
    public int     TotalCount { get; set; }

    public int TotalPages
    {
        get => m_TotalPages;
        init => m_TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
    }

    public bool HasPreviousPage
    {
        get => m_HasPreviousPage;
        init => m_HasPreviousPage = Page > 1;
    }

    public bool HasNextPage
    {
        get => m_HasNextPage;
        init => m_HasNextPage = Page * PageSize < TotalCount;
    }

    ////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////
}
