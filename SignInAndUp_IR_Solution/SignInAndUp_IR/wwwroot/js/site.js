function highlightActiveTab()
{
    var nothingActive = true;
    var current = location.pathname;

    $('.nav-tabs li a').each(function ()
    {
        let $this = $(this);
        let value = $this.attr('href');
        let index = current.indexOf(value);
        if (index !== -1)
        {
            $this.addClass('active');
            nothingActive = false;
            //return;
        }
    })
    if (nothingActive)
    {
        let defaultTab = $('.nav-tabs li a').first();
        defaultTab.addClass('active');
    }
}