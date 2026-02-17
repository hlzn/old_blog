<template>
    <div id="frontDoorHeader" :class="headerIs" @click="toggleClass()">
        <div id="frontDoorHeaderContent">
            <div class="menuContent">
                <ul class="theOptions">
                    <li class="menuOption"><a href="/">Home</a></li>
                    <li class="menuOption"><a href="/about">About</a></li>
                </ul>
            </div>
            <h4>
                <img height="20px" src="/public/logo.svg" alt="Logo" class="logo" />
                hlzn
            </h4>
        </div>
    </div>
    
</template>

<script setup lang="ts">
import { ref } from 'vue';
const headerIs = ref('closed');
const toggleClass = () => {
    if (headerIs.value === 'closed') {
        headerIs.value = 'open';
    } else {
        headerIs.value = 'closed';
    }
}
</script>