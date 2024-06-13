const accessingParaElement = () => {
    let para = document.getElementById('para1')
    console.log(para)
}

const nodeList = document.getElementsByName('gen')
console.log(nodeList)

const tagList = document.getElementsByTagName('P')
console.log(tagList)

const classList = document.getElementsByClassName('demo')
console.log(classList)

const paraId = document.querySelector('.para1')
console.log(paraId)