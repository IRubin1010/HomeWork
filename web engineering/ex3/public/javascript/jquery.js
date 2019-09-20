$(document).ready(function(){
   let hash = location.hash;
   if(hash !== ""){
       console.log(hash);
       let replacedHash = hash.replace('#', '');
       console.log(replacedHash);
       $( "#middle-page" ).load(replacedHash + ".ejs");
   }
});

$(document).ready(function() {
    $('a[href="#about"]').on("click",async function(){
            let res = await fetch("/about");
            try{
                let resJson = await res.json();
                let page = resJson.page;
                $( "#middle-page" ).load(page);
            }catch (e) {
                console.log(e);
            }
        }
    );
});

// $( "#middle-page" ).load( "<%= page %>" );