export async function requestBuilder(url, params,method,body) {
    let result = []
    if(!body){
        body=null
    }
    let requestUrl = await url + (params? "?" + Object.keys(params).map(function (key) {
        return (key + "=" + params[key] + "&")

    }).join(""):"")
    String.prototype.replace(",","");
    await fetch(requestUrl,{
        method:method,
        headers: {
            'Content-Type': 'application/json'
          },
        body:body
    }).then(async (response) => {
        result = await response.json();
    })
    return result;
}

