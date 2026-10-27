var tooltip;

(function (window, document) {

    /*
     * This code initializes all tooltips on the page and adds event listeners to buttons and inputs to change the
     * tooltip background color on hover.
     *
     * It uses Bootstrap's Tooltip component to create and manage tooltips.
     *
     * Color is defined in style section of this page
     *
     */
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));

    tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl);
    });

    const hoverElements = document.querySelectorAll("button, input");

    hoverElements.forEach(function (el) {

        el.addEventListener('mouseover',
            function () {

                const color = this.getAttribute('data-color');
                const tooltipInner = document.querySelector('.tooltip-inner');
            });

        el.addEventListener('mouseout',
            function () {
                const tooltipInner = document.querySelector('.tooltip-inner');
                if (tooltipInner) {
                    tooltipInner.style.backgroundColor = '';
                }
            });

    });

    tooltip = new bootstrap.Tooltip(document.getElementById('targetInput'));

})(window, document);