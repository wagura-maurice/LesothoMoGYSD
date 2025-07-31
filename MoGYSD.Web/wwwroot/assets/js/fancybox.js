import {Fancybox} from "https://cdn.jsdelivr.net/npm/@fancyapps/ui@5.0.36/dist/fancybox/fancybox.esm.js";

export function previewImage(url, gallery) {
    console.log(url);
    if (url == null) return;
    const fileName = getFileName(url);
    if (isImageUrl(url)) {
        let images = [];
        if (gallery != null && gallery.length > 0) {
            images = gallery.filter(l => isImageUrl(l)).map(x => ({src: x, caption: x.split("/").pop()}));
        } else {
            images = [{src: url, caption: url.split("/").pop()}];
        }
        Fancybox.show(images);
    } else if (isPDF(url)) {
        Fancybox.show([{ src: url, type: 'iframe', caption: fileName }]);
    } else {
        const anchorElement = document.createElement('a');
        anchorElement.href = url;
        anchorElement.download = fileName ?? '';
        anchorElement.click();
        anchorElement.remove();
    }
}

function isImageUrl(url) {
    const imageExtensions = /\.(gif|jpe?g|tiff?|png|webp|bmp)$/i;
    return imageExtensions.test(url);
}
function isPDF(url) {
    return url.toLowerCase().endsWith('.pdf');
}
function getFileName(url) {
    return url.split('/').pop();
}

//import { Fancybox } from "https://cdn.jsdelivr.net/npm/@fancyapps/ui@5.0.36/dist/fancybox/fancybox.esm.js";

//// Initialize Fancybox once when the page loads
//Fancybox.bind("[data-fancybox]", {
//    // Your options here
//    Thumbs: false,
//    Toolbar: true,
//});

//export function previewImage(url, gallery) {
//    if (!url) return;

//    const fileName = getFileName(url);

//    if (isImageUrl(url)) {
//        let images = [];
//        if (gallery?.length > 0) {
//            images = gallery.filter(l => isImageUrl(l))
//                .map(x => ({ src: x, caption: getFileName(x) }));
//        } else {
//            images = [{ src: url, caption: fileName }];
//        }

//        Fancybox.show(images, {
//            groupAll: true,
//            Thumbs: false
//        });

//    } else if (isPDF(url)) {
//        Fancybox.show([{
//            src: url,
//            type: 'iframe',
//            caption: fileName
//        }]);
//    } else {
//        downloadFile(url, fileName);
//    }
//}

//function downloadFile(url, fileName) {
//    const anchor = document.createElement('a');
//    anchor.href = url;
//    anchor.download = fileName || '';
//    document.body.appendChild(anchor);
//    anchor.click();
//    document.body.removeChild(anchor);
//}

//function isImageUrl(url) {
//    return /\.(gif|jpe?g|tiff?|png|webp|bmp)$/i.test(url);
//}

//function isPDF(url) {
//    return url.toLowerCase().endsWith('.pdf');
//}

//function getFileName(url) {
//    return url.split('/').pop();
//}