﻿(function () {
    "use strict";

    WinJS.UI.Pages.define("/demos/listviews/circle/circle.html", {
        init: function (element, options) {
            var uniqueId = 0;

            var attractions = [
                { name: "Fern Grotto", category: "Flora", location: "East", imageUrl: "http://www.kauai.com/photos/kauai/point/98/super/fern_grotto-kauai-attraction.JPG", description: "Only accessible by boat or Kayak, the fern Grotto is located about two miles up Kauai’s Wailua River, the only navigable river in the State of Hawaii." },
                { name: "Hanalei Valley Lookout", category: "Scenery", location: "North", imageUrl: "http://www.kauai.com/photos/kauai/point/51/super/hanalei-valley-lookout-kauai-attractions-3.jpg", description: "The Hanalei Valley is an enchanted site charmed with the likes of countless waterfalls, rainbows, fields of taro and hidden treasures waiting to be explored." },
                { name: "Hanapepe Swinging Bridge", category: "Other", location: "West", imageUrl: "http://www.kauai.com/photos/kauai/point/93/super/843726541306971801.jpg", description: "Located in old town Hananpepe a Historical sight made up of an eclectic group of galleries and shops. Home to Friday night Art walk." },
                { name: "Kalalau Lookout", category: "Scenery", location: "West", imageUrl: "http://www.kauai.com/photos/kauai/point/94/super/3075381091306977440.jpg", description: "The Kalalau lookout stands at 4,00 feet above sea level and gives you a peek at a valley that as late as the 1920's still was the home to residents who farmed crops there. The only way into the valley is by foot along the Kalalau Trail or by boat." },
                { name: "Kauai Coastal Path", category: "Coastline", location: "East", imageUrl: "http://www.kauai.com/photos/kauai/point/100/super/kauai-coastal-path-kauai-attractions.JPG", description: "Kauai Coastal Path is a scenic and and safe place to walk, run or bike while taking in the beautiful scenery of Kauai's East Side." },
                { name: "Keahua Arboretum", category: "Flora", location: "East", imageUrl: "http://www.kauai.com/photos/kauai/point/95/super/keahua-arboretum-kauai-attractions-5.JPG", description: "The Keahua Arboretum is planted with native and introduced plants by the University of Hawaii and is used as an outdoor classroom to students and visitors. Cool off in the cold mountain spring water and enjoy lunch at one of the picnic sites." },
                { name: "Kilauea Lighthouse National Wildlife Preserve", category: "Coastline", location: "North", imageUrl: "http://www.kauai.com/photos/kauai/point/49/super/kilauea_lighthouse_national_wildlife_preserve-kauai-attraction.JPG", description: "Kilauea Point National Wildlife Refuge started in 1985 by the U.S. Fish and Wildlife Service is marked by its towering lighthouse. The ocean cliffs and tall grassy slopes of a dormant volcano provide a protective breeding ground for many Hawaiian seabirds" },
                { name: "Koloa Landing", category: "Coastline", location: "South", imageUrl: "http://www.kauai.com/photos/kauai/point/99/super/koloa-landing-kauai-attractions-2.jpg", description: "Once one of the largest deep water whaling ports in Hawaii, Koloa Landing is now a popular location for shore dives." },
                { name: "Lawai International Center", category: "Other", location: "South", imageUrl: "http://www.kauai.com/photos/kauai/point/110/super/lawai-international-center-kauai-attractions.JPG", description: "Lawai International Center and the 88 Shrines are located on the ancient site of Heiau where Hawaiians once came for healing." },
                { name: "Menehune Fishpond", category: "Other", location: "East", imageUrl: "http://www.kauai.com/photos/kauai/point/48/super/menehune-fishpond-kauai-attractions.JPG", description: "Menehune Fish Pond is located just above the Nawiliwili Harbor. The Menuhune Fish Pond, Alekoko got it's name from the legend that a small race of people known as menehune built these ponds 1,000 years ago overnight." },
                { name: "Napali Coast", category: "Coastline", location: "North", imageUrl: "http://www.kauai.com/photos/kauai/point/82/super/napali-coast-kauai-attractions.jpg", description: "The Napali is a fifteen mile stretch of coastline starting on the north shore at Kee beach and ending on the west side at Polihale beach. This rugged coast will leave you breathless as you gaze upon the he razor sharp cliffs that rise sharply from sea to " },
                { name: "Opaekaa Falls", category: "Waterfall", location: "East", imageUrl: "http://www.kauai.com/photos/kauai/point/88/super/opaekaa_falls-kauai-attraction.JPG", description: "Opaekaa Falls can be seen from the scenic lookout along Kuamoo Road in the Wailua Homesteads. " },
                { name: "Spouting Horn", category: "Coastline", location: "South", imageUrl: "http://www.kauai.com/photos/kauai/point/86/super/spouting-horn-kauai-attractions-1.JPG", description: "Spouting Horn Beach Park is a delightful lookout where you can watch a blowhole spout a plume of sea water into the air." },
                { name: "Tree Tunnel", category: "Flora", location: "South", imageUrl: "http://www.kauai.com/photos/kauai/point/91/super/tree-tunnel-kauai-attractions.JPG", description: "The beautiful canopy of eucalyptus trees line Maliuhi Road, the gateway to Kauai's sunny side and the towns of Koloa, and Poipu." },
                { name: "Wailua Falls", category: "Waterfall", location: "East", imageUrl: "http://www.kauai.com/photos/kauai/point/50/super/wailua_falls-kauai-attraction.JPG", description: "This 140 foot waterfall appears on many postcards, print and media collections and was used as the opening scene for the 1970’s Television series Fantasy Island." },
                { name: "Waimea Canyon", category: "Other", location: "West", imageUrl: "http://www.kauai.com/photos/kauai/point/83/super/waimea-canyon-kauai-attractions-2.JPG", description: "Waimea Canyon State Park is the largest canyon in the Pacific and will undoubtedly capture your gaze, with its 10 mile long stretch at a mile wide and measuring more than 3,500 feet deep." },
                { name: "Wet and Dry Caves", category: "Other", location: "North", imageUrl: "http://www.kauai.com/photos/kauai/point/111/super/wet-and-dry-caves-kauai-attractions.jpg", description: "Waikanaloa & Waikapalae Wet Caves are located off the the main road in the Haena State Park and are easy to get to. The Waikanaloa Cave is not for swimming. The Waikapale cave is located a a little further up the road and involves a quick hike to the swim" },
            ];

            WinJS.Namespace.define("codeShow.Demos.listviews.circle", {
                attractionsList: new WinJS.Binding.List(attractions),
                add: function () { this.attractionsList.push(attractions[Math.floor(Math.random() * attractions.length)]); },
                remove: function () { this.attractionsList.pop(); },
                CircleLayout: WinJS.Class.define(
                    function CircleLayout() {},
                    {
                    initialize: function (site) {
                        this._site = site;
                        return "vertical";
                    },
                    layout: function (tree, range, modifiedItems, modifiedGroups) {
                        var site = this._site;
                        var tree = site.tree;

                        var count = 0;
                        for (var groupIndex = 0; groupIndex < tree.length; groupIndex++) {
                            var items = tree[groupIndex].itemsContainer.items;
                            for (var itemIndex = 0; itemIndex < items.length; itemIndex++) {
                                count++;
                            }
                        }

                        var itemWidth = 107;
                        var itemHeight = 76;
                        var halfItemWidth = itemWidth / 2;
                        var halfItemHeight = itemHeight / 2;
                        var diameter = Math.min(site.viewportSize.height - itemHeight - halfItemHeight, site.viewportSize.width - itemWidth - halfItemWidth);
                        var radius = diameter / 2;
                        var centerPointY = (site.viewportSize.height - itemHeight) / 2;
                        var centerPointX = (site.viewportSize.width - itemWidth) / 2;

                        var distanceBetweenItemsInRadians = count ? 2 * Math.PI / count : 0;

                        var absoluteItemIndex = 0;

                        for (var groupIndex = 0; groupIndex < tree.length; groupIndex++) {
                            var groupBundle = tree[groupIndex];
                            var groupHeader = groupBundle.header;
                            var itemsContainer = groupBundle.itemsContainer;
                            var itemsContainerEl = itemsContainer.element;
                            var items = itemsContainer.items;
                            for (var itemIndex = 0; itemIndex < items.length; itemIndex++) {
                                var container = items[itemIndex];

                                var posX = radius * Math.cos(distanceBetweenItemsInRadians * (count - 1 - absoluteItemIndex) - Math.PI / 2);
                                var posY = radius * Math.sin(distanceBetweenItemsInRadians * (count - 1 - absoluteItemIndex) - Math.PI / 2);

                                container.style.left = centerPointX + "px";
                                container.style.top = centerPointY + "px";

                                if (container.style.opacity === "") {
                                    container.style.opacity = "0";
                                    container.style.opacity.transition = "none";
                                    getComputedStyle(container).opacity;
                                    container.style.opacity.transition = "";
                                    container.style.opacity = "1";
                                }

                                container.style.transform = "translate(" + posX + 'px, ' + posY + 'px)';

                                absoluteItemIndex++;
                            }
                        }
                    }
                })

            });
        }
    });
})();
