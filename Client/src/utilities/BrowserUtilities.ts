const browserUtilities = {
    isMobile: () => {
        return window.innerWidth < 768;
    },
    isTablet: () => {
        return window.innerWidth >= 768 && window.innerWidth < 1024;
    },
    isDesktop: () => {
        return window.innerWidth >= 1024;
    },
    scrollToTopIfSmallScreen: () => {
        if (browserUtilities.isMobile() || browserUtilities.isTablet()) {
            window.scrollTo({
                top: 0,
                behavior: 'smooth'
            });
        }
    }
};

export default browserUtilities;