(function () {
    "use strict";

    // Define some variables
    var mql = window.matchMedia("(min-width: 992px)");
    var allSidebars = document.querySelectorAll(".sidebar");
    var mainSidebar = document.querySelector(".sidebar.page-sidebar");
    var messageSidebar = document.querySelector(".message-sidebar");
    var pageOverlay = document.querySelector(".page-overlay");

    function makeArray(list) {
        return [].slice.call(list);
    }

    // Toggle sidebars on viewport width changes
    var mediaQueryChanged = function () {
        makeArray(allSidebars).forEach(function (sidebar) {
            if (!mql.matches) sidebar.style.transform = "translateX(-100%)";
            else sidebar.style.transform = "translateX(0)";
        });
    };

    // Listen for viewport width changes
    mql.addListener(mediaQueryChanged);

    // Close sidebars on page load if mobile width
    if (!mql.matches)
        makeArray(allSidebars).forEach(function (sidebar) {
            sidebar.style.transform = "translateX(-100%)";
        });

    // Render lottie animated icons
    makeArray(document.querySelectorAll(".animated-icon > div")).forEach(function (
        icon
    ) {
        lottie.loadAnimation({
            container: icon,
            renderer: "svg",
            loop: icon.dataset.loop === "true" ? true : false,
            autoplay: icon.dataset.autoPlay === "true" ? true : false,
            path: icon.dataset.animationPath
        });
    });

    // Sidebar navigation
    makeArray(document.querySelectorAll(".sidebar-item > .nav-item > a")).forEach(
        function (menuItem) {
            menuItem.addEventListener("click", function (e) {
                var subMenu = menuItem.nextElementSibling;
                var otherLinks = makeArray(
                    document.querySelectorAll(".sub-menu.collapse")
                ).filter(function (link) {
                    return link !== subMenu;
                });
                var caret = menuItem.querySelector(".caret");
                var otherCarets = makeArray(document.querySelectorAll(".caret")).filter(
                    function (otherCaret) {
                        return otherCaret !== caret;
                    }
                );

                if (!subMenu.classList.contains("collapse")) return;

                otherLinks.map(function (elm) {
                    elm.classList.remove("show");
                });

                otherCarets.map(function (elm) {
                    elm.classList.remove("caret-active");
                });

                if (subMenu.classList.contains("show")) {
                    subMenu.classList.remove("show");
                    caret.classList.remove("caret-active");
                } else {
                    subMenu.classList.add("show");
                    caret.classList.add("caret-active");
                }

                if (menuItem.getAttribute("href") === "javascript:;") {
                    e.preventDefault();
                }

                e.stopPropagation();
                return true;
            });
        }
    );

    // Toggle sidebars on overlay click
    pageOverlay.addEventListener("click", function (e) {
        makeArray(allSidebars).forEach(function (sidebar) {
            sidebar.style.transform = "translateX(-100%)";
        });
        pageOverlay.style.visibility = "hidden";
        pageOverlay.style.opacity = "0";
    });

    // Toggle sidebar collapsed
    document
        .querySelector(".sidebar .nav-toggle")
        .addEventListener("click", function (e) {
            var page = document.querySelector("body .page");

            if (page.classList.contains("page-sidebar-collapsed")) {
                page.classList.remove("page-sidebar-collapsed");
            } else {
                page.classList.add("page-sidebar-collapsed");
            }
        });

    // Toggle sidebar collapsed
    document
        .querySelector("#collapsedSidebarOption")
        .addEventListener("change", function (e) {
            var page = document.querySelector("body .page");

            if (e.target.checked) {
                page.classList.add("page-sidebar-collapsed");
            } else {
                page.classList.remove("page-sidebar-collapsed");
            }
        });

    // Toggle fullscreen mode
    makeArray(document.querySelectorAll(".toggle-fullscreen")).forEach(function (
        fullScreenToggler
    ) {
        fullScreenToggler.addEventListener("click", function (e) {
            var element = document.querySelector("body");
            var isFullscreen =
                document.webkitIsFullScreen || document.mozFullScreen || false;

            element.requestFullScreen =
                element.requestFullScreen ||
                element.webkitRequestFullScreen ||
                element.mozRequestFullScreen ||
                function () {
                    return false;
                };

            document.cancelFullScreen =
                document.cancelFullScreen ||
                document.webkitCancelFullScreen ||
                document.mozCancelFullScreen ||
                function () {
                    return false;
                };

            isFullscreen ? document.cancelFullScreen() : element.requestFullScreen();
        });
    });

    // Toggle dark mode
    document
        .querySelector("#darkModeOption")
        .addEventListener("change", function (e) {
            var page = document.querySelector("body .page");

            if (e.target.checked) {
                page.classList.add("dark-mode");
            } else {
                page.classList.remove("dark-mode");
            }
        });

    // Toggle boxed layout
    document
        .querySelector("#boxedOption")
        .addEventListener("change", function (e) {
            var page = document.querySelector("body .page");

            if (e.target.checked) {
                page.classList.add("page-boxed");
            } else {
                page.classList.remove("page-boxed");
            }
        });

    // Toggle sticky header
    document
        .querySelector("#stickyHeaderOption")
        .addEventListener("change", function (e) {
            var page = document.querySelector("body .page");

            if (e.target.checked) {
                page.classList.add("page-sticky-header");
            } else {
                page.classList.remove("page-sticky-header");
            }
        });

    // Toggle sticky sidebar
    document
        .querySelector("#stickySidebarOption")
        .addEventListener("change", function (e) {
            var page = document.querySelector("body .page");

            if (e.target.checked) {
                page.classList.add("page-sticky-sidebar");
            } else {
                page.classList.remove("page-sticky-sidebar");
            }
        });

    // Toggle top header
    document
        .querySelector("#topHeaderOption")
        .addEventListener("change", function (e) {
            var page = document.querySelector("body .page");

            if (e.target.checked) {
                page.classList.add("page-top-header");
            } else {
                page.classList.remove("page-top-header");
            }
        });

    // Toggle sidebar on mobile view
    makeArray(document.querySelectorAll(".app-header .nav-toggle")).forEach(
        function (toggler) {
            toggler.addEventListener("click", function (e) {
                if (
                    !mql.matches &&
                    mainSidebar.style.transform === "translateX(-100%)"
                ) {
                    mainSidebar.style.transform = "translateX(0)";
                    pageOverlay.style.visibility = "visible";
                    pageOverlay.style.opacity = "1";
                } else {
                    mainSidebar.style.transform = "translateX(-100%)";
                    pageOverlay.style.visibility = "hidden";
                    pageOverlay.style.opacity = "0";
                }
            });
        }
    );

    // Toggle messages sidebar on mobile view
    makeArray(document.querySelectorAll(".messages-nav-toggler")).forEach(
        function (toggler) {
            toggler.addEventListener("click", function (e) {
                if (
                    !mql.matches &&
                    messageSidebar.style.transform === "translateX(-100%)"
                ) {
                    messageSidebar.style.transform = "translateX(0)";
                    pageOverlay.style.visibility = "visible";
                    pageOverlay.style.opacity = "1";
                } else {
                    messageSidebar.style.transform = "translateX(-100%)";
                    pageOverlay.style.visibility = "hidden";
                    pageOverlay.style.opacity = "0";
                }
            });
        }
    );

    // Make taskboard items sortable
    makeArray(document.querySelectorAll(".app-taskboard-cards > div")).forEach(
        function (group) {
            new Sortable(group, {
                group: "taskboard",
                animation: 150
            });
        }
    );

    // Tooltip and popover demos
    makeArray(document.querySelectorAll('[data-toggle="tooltip"]')).forEach(
        function (tooltip) {
            new bootstrap.Tooltip(tooltip);
        }
    );

    makeArray(document.querySelectorAll('[data-toggle="popover"]')).forEach(
        function (popover) {
            new bootstrap.Popover(popover);
        }
    );
})();
