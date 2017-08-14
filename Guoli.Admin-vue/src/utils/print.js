
let closePrint = function () {
  document.body.removeChild(this.__container__);
};

let setPrint = function () {
  this.contentWindow.__container__ = this;
  this.contentWindow.onbeforeunload = closePrint;
  this.contentWindow.onafterprint = closePrint;
  this.contentWindow.focus(); // Required for IE
};


let getIframe = function () {
  let iframeId = '__iframeForPrint__';
  let iframe = document.getElementById(iframeId);
  if (iframe && iframe.contentWindow) {
    let d = iframe.contentWindow.document;
    d.head.innerHTML = '';
    d.body.innerHTML = '';
  } else {
    if (iframe) {
      document.body.removeChild(iframe);
    }

    iframe = document.createElement('iframe');
    iframe.id = iframeId; iframe.onload = setPrint;
    iframe.style.visibility = "hidden";
    document.body.appendChild(iframe);
  }

  return iframe;
};

export default function (id) {
  let iframe = getIframe();
  let doc = iframe.contentWindow.document;

  let styles = document.getElementsByTagName('style');
  for (let i = 0; i < styles.length; i++) {
    doc.head.appendChild(styles[i].cloneNode(true));
  }

  let printDom = document.getElementById(id).cloneNode(true);
  doc.body.appendChild(printDom);

  // console.info(iframe);
  iframe.contentWindow.print();
};

