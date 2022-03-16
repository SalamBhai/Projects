var headpage = document.getElementById("asd");
// var landingcss = document.createElement("link");
// landingcss.rel = "stylesheet";
// landingcss.href = "DictionaryLanding.css";
// landingcss.setAttribute('id', "dland");
// var resultcss = document.getElementById("dresult");
// // headpage.removeChild(resultcss);
// headpage.appendChild(landingcss);


var searchBox = document.getElementById("searchBox");
var containerinf = document.getElementById("containerinf");
var searchbtn = document.getElementById("searchbtn");
var landingcss = document.getElementById("dland");
var word = document.getElementById("wordSearched");
var firstConcern = document.getElementById("firstConcern");
var secondConcern = document.getElementById("secondConcern");
var oralRep = document.getElementById("oralRep");
var audioBtncontainer = document.getElementById("buttonCont");
var pronunciation = document.getElementById("pron");
var SlsAndOral = document.getElementById("slsAndoral");
var searchForm = document.getElementById("searchform");
var definationHead = document.getElementById("defi");
var partOfSpeech = document.getElementById("fl");
var upinS2 = document.getElementById("up");
var shortDefination = document.getElementById("defcont");
var useInSentence = document.getElementById("useHead");
var theUse = document.getElementById("usage");
var initial = document.getElementById("init");
var initialContainer = document.getElementById("initial");
var partofSpeech2 = document.getElementById("fl2");
var wordInSecondConcern = document.getElementById("wordinsc");
var reg1 = document.getElementById("reg1");
var reg2 = document.getElementById("reg2");
var meaningAndUsage = document.getElementById("meaningandusage");
var meanings = document.getElementById("meanings");
var audioPron = document.getElementById("pronunciation");
var prevandNext = document.getElementById("prevandnext");
var next = document.getElementById("chevnex");
var audioBtn = document.getElementById("btn");
var srcofAudio = document.getElementById("src");
var userprofile = document.getElementById("userprofile");
var navbar = document.getElementById("navbar");
console.log(navbar);
var sidebar = document.getElementById("sidebar");
var FirstKnownUseContent = document.getElementById("FirstKnownUseContent");
var EtymologyContent = document.getElementById("EtymologyContent");
var fronttems = document.getElementById("fi");
var sides = document.getElementById("sides");
var headofInflection = document.getElementById("headInf");
console.log(srcofAudio);
const responseArray = [];
const arrayofhomsAndOffensiveCheck = [];
searchbtn.addEventListener('click', function(e) {
            e.preventDefault();
            var text = searchBox.value;
            console.log(text);
            alert(`"Please wait while I search ${text}"`);
            fetch(`https://www.dictionaryapi.com/api/v3/references/collegiate/json/${text}?key=ea90f273-699f-4d3f-9ece-8ae6a91f0eda`)
                .then(function(searchResult) {
                    return searchResult.json();
                })
                .then(function(finalResult) {

                        for (let response of finalResult) {
                            responseArray.push(response);
                            arrayofhomsAndOffensiveCheck.push(response.hom);
                            arrayofhomsAndOffensiveCheck.push(response.meta);
                        }
                        console.log(finalResult);
                        word.innerHTML = finalResult[0].hwi.hw;
                        oralRep.textContent = `${`["${finalResult[0].hwi.prs[0].mw}"]`}`;
                        shortDefination.innerHTML = `"<i>${finalResult[0].shortdef[0]}</i>"`;
                        partOfSpeech.innerHTML = `<i>${finalResult[0].fl}:</i>`;
                        if(finalResult[0].quotes !== undefined)  theUse.innerHTML = finalResult[0].quotes[0].t;
                        else 
                        {
                            theUse.style.visibility = "hidden";
                            useInSentence.style.visibility = "hidden";
                        }
                        
                     if((finalResult[0].hwi.prs[0].sound.audio).slice(0,2) ==="gg")  srcofAudio.setAttribute("src", `https://media.merriam-webster.com/audio/prons/en/us/mp3/gg/${finalResult[0].hwi.prs[0].sound.audio}.mp3`);
                     else if((finalResult[0].hwi.prs[0].sound.audio).slice(0,3) ==="bix")  srcofAudio.setAttribute("src", `https://media.merriam-webster.com/audio/prons/en/us/mp3/bix/${finalResult[0].hwi.prs[0].sound.audio}.mp3`);
                     else
                     {
                        srcofAudio.setAttribute("src", `https://media.merriam-webster.com/audio/prons/en/us/mp3/${finalResult[0].hwi.prs[0].sound.audio[0]}/${finalResult[0].hwi.prs[0].sound.audio}.mp3`);
                     }

                         console.log("src", srcofAudio);
                          audioBtn.appendChild(srcofAudio);
                          
                          if(finalResult[0].meta.offensive === true)  SlsAndOral.setAttribute("placeholder",`"${"Offensive Word"}"`);
                          else
                          {
                            SlsAndOral.setAttribute("placeholder",`"${"Not Offensive Word"}"`);
                          }
                          initial.textContent = (finalResult[0].fl[0]).toUpperCase();
                          partofSpeech2.innerHTML = (finalResult[0].fl).toUpperCase();
                          headofInflection.textContent = ` Change In Form Of ${text}`
                          wordInSecondConcern.textContent = text;
                          FirstKnownUseContent.innerHTML = ` The First Known Use Of ${text} was  <i>${finalResult[0].date}</i> in the above defination `;
                          EtymologyContent.innerHTML =  `<i>${finalResult[0].et[0][1]}:</i>`;
                         if(finalResult[0].et[0][1] === null )  EtymologyContent.style.visibility=  "hidden";
                           
                         for (let i = 0; i < finalResult[0].def[0].sseq.length; i++) 
                         {
                            var sensualMeaning = document.createElement('li');
                            sensualMeaning.classList.add("meaning");
                            sensualMeaning.innerHTML = finalResult[0].def[0].sseq[i][0][1].dt[0][1];
                            console.log(finalResult[0].def[0].sseq[i][0][1].dt[0][1]);
                            meaningAndUsage.appendChild(sensualMeaning);
                            
                         }
                           
                          headpage.removeChild(landingcss);
                          console.log(headpage);
                          setInterval(function()
                          {
                            
                            fronttems.style.visibility ="hidden"
                            firstConcern.style.visibility= "visible";
                            secondConcern.style.visibility = "visible";
                            userprofile.style.visibility = "visible";
                            navbar.style.visibility = "visible";
                            sides.style.visibility = "visible";
                          },1000)
                               
                          
                }) 
                .catch(function() {
                   console.error("Ona di");
                })
                
})
navbar.addEventListener("click", function()
                {
                    console.log(navbar);
                    sidebar.style.visibility = "visible";
                    navbar.style.visibility = "hidden";
                    sidebar.addEventListener("click",function()
                    {
                        sidebar.style.visibility = "hidden";
                        navbar.style.visibility = "visible";
                    })
                    setTimeout(function()
                    {
                        sidebar.style.visibility = "hidden";
                        navbar.style.visibility = "visible";
                    },50000)
                    
                })
document.addEventListener('scroll', function()
                {
                   sidebar.style.position = "static";
                   console.log("Iam executting")
                })