<?php
/*
 * Plugin Name: Our First Plugin
 * Description: Amazing Plugin
 * Version: 0.1
 * Author: Laura Haselberger
 * Author URI: https://htlkrems.ac.at
 */

function addDate($content){
    return $content."<p><em>".date('d.m.Y')."</em></p>";
}
// Hook
// add_filter('the_content', 'addDate');

add_shortcode('current_date', 'addDate');

?>