"use strict";

let buttons=document.querySelectorAll(".categoryButton")
let cards=document.querySelectorAll(".card")
let monthlyBtn=document.querySelector(".monthly")
let annuallyBtn=document.querySelector(".annual")
let tabContent=document.querySelectorAll(".tabContent")
let closeBtn=document.querySelector(".close")
let hamburgerBtn=document.querySelector(".hamburger")
let bodyOverlay=document.querySelector(".body-overlay")
let sidebarArea=document.querySelector(".sidebar__area")
let leftBtns=document.querySelectorAll(".leftBtn")

hamburgerBtn.addEventListener("click",()=>{
    bodyOverlay.classList.add("opened")
    sidebarArea.classList.add("sidebar-opened")
})

closeBtn.addEventListener("click",()=>{
    bodyOverlay.classList.remove("opened")
    sidebarArea.classList.remove("sidebar-opened")
})

bodyOverlay.addEventListener("click",()=>{
    bodyOverlay.classList.remove("opened")
    sidebarArea.classList.remove("sidebar-opened")
})


leftBtns.forEach(btn=>{
    btn.addEventListener("click",(e)=>{
        e.preventDefault()
        if(btn.classList.contains("rotated")){
            btn.classList.remove("rotated")
            btn.nextElementSibling.style.display="none"
        }
        else{
            btn.classList.add("rotated")
            btn.nextElementSibling.style.display="block"
        }
    })
})



// closeBtn.addEventListener("click",()=>{

// })



monthlyBtn.addEventListener("click",(e)=>{
    e.preventDefault()
    tabContent[1].style.display="none";
    tabContent[0].style.display="flex";
    if(!e.target.classList.contains("active")){
        e.target.classList.add("active")
        annuallyBtn.classList.remove("active")
    }
  
})

annuallyBtn.addEventListener("click",(e)=>{
    e.preventDefault()
    tabContent[0].style.display="none";
    tabContent[1].style.display="flex";

    if(!e.target.classList.contains("active")){
        e.target.classList.add("active")
        monthlyBtn.classList.remove("active")
    }
  
})





let allCategories = document.querySelectorAll(".categoryButton")


let featuredCards = document.querySelectorAll(".featuredCard")



allCategories.forEach(header => {
    header.addEventListener("click", function () {

        //console.log(this.getAttribute("data-id"))

        //for (const item of featuredCards) {
        //    console.log(item.getAttribute("data-id"))
        //}
        
        debugger
        if (this.getAttribute("data-id") == 0) {
            for (const item of featuredCards) {
                item.classList.remove("d-none");
            }
        } else {
            for (const item of featuredCards) {
                if (item.getAttribute("data-id") == this.getAttribute("data-id")) {
                    item.classList.remove("d-none");
                } else {
                    item.classList.add("d-none");
                }
            }
        }
    });
});




//buttons.forEach(button=>{
//    button.addEventListener("click",(e)=>{
//        e.preventDefault()
//        if(e.target.classList.contains("all")){
//            cards.forEach(card=>{
//                card.style.display="block"
//            })
//        }else if(e.target.classList.contains("popular")){
//            cards.forEach(card=>{
//                if(card.classList.contains("popular")){
//                    card.style.display="block"
//                }else{
//                    card.style.display="none"
//                }
//            })
//        }else if(e.target.classList.contains("trendingbtn")){
//            cards.forEach(card=>{
//                if(card.classList.contains("trendingCard")){
//                    card.style.display="block"
//                }else{
//                    card.style.display="none"
//                }
//            })
//        }else if(e.target.classList.contains("featured")){
//            cards.forEach(card=>{
//                if(card.classList.contains("featuredCard")){
//                    card.style.display="block"
//                }else{
//                    card.style.display="none"
//                }
//            })
//        }else if(e.target.classList.contains("art")){
//            cards.forEach(card=>{
//                if(card.classList.contains("artCard")){
//                    card.style.display="block"
//                }else{
//                    card.style.display="none"
//                }
//            })
//        }
        
//    })
//})