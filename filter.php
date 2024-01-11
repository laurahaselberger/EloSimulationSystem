<?php
/*
 * Plugin Name: Text Filter Plugin
 * Description: Das Plugin ersetzt bestimmte Wörter in einem gegebenen Text.
 * Version: 0.1
 * Author: Laura Haselberger
 * Author URI: https://htlkrems.ac.at
 */

function AddTextFilter($content) {
    return str_replace('scheisse', 'nicht perfekt', $content);
}
// Hook
add_filter('the_content', 'AddTextFilter');
?>